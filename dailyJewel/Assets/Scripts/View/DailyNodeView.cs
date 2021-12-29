using System;
using Entity;
using SimpleJSON;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using EventType = Entity.EventType;
using Random = UnityEngine.Random;

namespace View
{
    public class DailyNodeView : MonoBehaviour
    {
        
        [SerializeField] private GameObject btnBuy;

        [SerializeField] private GameObject hasBuy;

        [SerializeField] private Image cardImage;

        [SerializeField] private Text cardColdLabel;

        [SerializeField] private GameObject moneyImage;

        [SerializeField] private Text countLabel;

        private int rewardType;

        private JSONNode itemData;

        public static DailyNodeView Singleton;

        private void Awake()
        {
            Singleton = this;
            EventCenter.AddListener<JSONNode>(EventType.DailyJewelInit, InitData);
        }

        public void OnBtnBuy()
        {
            itemData["isPurchased"] = "1";
            FreshDisplay();
            if (rewardType == (int) RewardType.Coins)
            {
                string coinNum = itemData.GetValueOrDefault("num", 1);
                MyAssetsView.Singleton.AddCoins(Convert.ToInt32(coinNum));

                var myCanvas = GameObject.Find("Canvas");
                myCanvas.SendMessage("CreateCoin");
            }
            else if (rewardType == (int) RewardType.Diamonds)
            {
                string diaNum = itemData.GetValueOrDefault("num", 1);
                MyAssetsView.Singleton.AddCoins(Convert.ToInt32(diaNum));
                MainView.Singleton.CreateCoin();
            }
        }


        public void InitData(JSONNode jsonNode)
        {
            this.itemData = jsonNode;
            this.InitDisplay();
        }

        private void FreshDisplay()
        {
            string value = itemData.GetValueOrDefault("isPurchased", 1);
            btnBuy.SetActive(Convert.ToInt16(value) == -1);
            hasBuy.SetActive(Convert.ToInt16(value) == 1);
        }

        private void InitDisplay()
        {
            string type = itemData.GetValueOrDefault("type", 1);
            rewardType = Convert.ToInt32(type);
            string value = itemData.GetValueOrDefault("isPurchased", 1);
            btnBuy.SetActive(Convert.ToInt16(value) == -1);
            hasBuy.SetActive(Convert.ToInt16(value) == 1);

            //刷新card
            string subType = itemData.GetValueOrDefault("subType", null);
            if (string.IsNullOrEmpty(subType))
            {
                float randow = Random.Range(0, 1.0f);
                if (randow > 0.5)
                {
                    cardImage.sprite = Resources.Load("awards/coin_1", typeof(Sprite)) as Sprite;
                }
                else
                {
                    cardImage.sprite = Resources.Load("awards/diamond_2", typeof(Sprite)) as Sprite;
                }
            }
            else
            {
                cardImage.sprite = Resources.Load("cards/" + subType, typeof(Sprite)) as Sprite;
            }

            if (cardImage.sprite != null)
            {
                cardImage.rectTransform.sizeDelta
                    = new Vector2(cardImage.sprite.rect.width * 0.65f, cardImage.sprite.rect.height * 0.65f);
            }

            //数量
            string count = itemData.GetValueOrDefault("num", 1);
            countLabel.text = string.Concat("x", count);

            //货币
            string costGold = itemData.GetValueOrDefault("costGold", 1);
            string costGem = itemData.GetValueOrDefault("costGem", 1);
            if (Convert.ToInt64(costGold) > 0)
            {
                cardColdLabel.text = costGold;
            }
            else if (Convert.ToInt64(costGem) > 0)
            {
                cardColdLabel.text = costGem;
            }
            else
            {
                moneyImage.SetActive(false);
                cardColdLabel.text = "免费";
            }
        }
    }
}
using System;
using Entity;
using Model;
using SimpleJSON;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using EventType = Entity.EventType;

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

        private int needCoin = 0;

        private void Awake()
        {
            Singleton = this;
            EventCenter.AddListener<JSONNode>(EventType.DailyJewelInit, InitData);
        }

        public void BuyCard()
        {
            if (GameModel.CreateInstance().MyCoinCount < needCoin)
            {
                EventCenter.PostEvent(Entity.EventType.ShowToask, "金币不足");
                return;
            }
            //扣金币
            EventCenter.PostEvent(Entity.EventType.FreshCoinCount, -needCoin);
            
            itemData["isPurchased"] = "1";
            FreshDisplay();
            if (rewardType == (int) RewardType.Diamonds)
            {
                string coinNum = itemData.GetValueOrDefault("num", 1);
                
                EventCenter.PostEvent(Entity.EventType.FreshCoinCount, Convert.ToInt32(coinNum));
                MainView.Singleton.CreateCoin(Math.Min(Convert.ToInt32(coinNum), 15));
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
                cardImage.sprite = Resources.Load("awards/coin_1", typeof(Sprite)) as Sprite;
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
            needCoin = int.Parse(costGold);
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
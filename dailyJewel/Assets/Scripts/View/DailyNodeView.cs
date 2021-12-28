using System;
using Controller;
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
        // Start is called before the first frame update

        [SerializeField] private GameObject btnBuy;
        [SerializeField] private GameObject hasBuy;

        [SerializeField] private Image cardImage;
        [SerializeField] private Text cardColdLabel;
        [SerializeField] private GameObject moneyImage;
        [SerializeField] private Text countLabel;

        private int rewardType;
        public JSONNode ItemData;

        private void Start()
        {
            EventCenter.AddListener<JSONNode>(EventType.DailyJewelInit, InitData);
        }

        public void OnBtnBuy()
        {
            this.ItemData["isPurchased"] = "1";
            this.FreshDisplay();
            if (rewardType == (int) RewardType.Coins)
            {
                //itemData.TryGetValue("num", out coinNum);
                string coinNum = ItemData.GetValueOrDefault("num", 1);
                GameObject myAssets;
                myAssets = GameObject.Find("Canvas/dailyJewel/myAssets");
                myAssets.SendMessage("AddCoins", Convert.ToInt32(coinNum));
                // myAssets.GetComponent<MyAssetsCtrl>().AddCoins(Convert.ToInt32(coinNum));

                GameObject myCanvas;
                myCanvas = GameObject.Find("Canvas");
                myCanvas.SendMessage("CreateCoin");
            }
            else if (rewardType == (int) RewardType.Diamonds)
            {
                string diaNum = ItemData.GetValueOrDefault("num", 1);
                GameObject myAssets;
                myAssets = GameObject.Find("Canvas/dailyJewel/myAssets");
                Debug.Log(myAssets);
                // myAssets.SendMessage("AddDiamonds", Convert.ToInt32(diaNum));
                myAssets.SendMessage("AddCoins", Convert.ToInt32(diaNum));

                GameObject myCanvas;
                myCanvas = GameObject.Find("Canvas");
                myCanvas.SendMessage("CreateCoin");
            }
        }


        public void InitData(JSONNode jsonNode)
        {
            Debug.Log(jsonNode);
            this.ItemData = jsonNode;
            this.InitDisplay();
        }

        public void FreshDisplay()
        {
            string value = ItemData.GetValueOrDefault("isPurchased", 1);
            btnBuy.SetActive(Convert.ToInt16(value) == -1);
            hasBuy.SetActive(Convert.ToInt16(value) == 1);
        }

        public void InitDisplay()
        {
            string type = ItemData.GetValueOrDefault("type", 1);
            rewardType = Convert.ToInt32(type);
            string value = ItemData.GetValueOrDefault("isPurchased", 1);
            btnBuy.SetActive(Convert.ToInt16(value) == -1);
            hasBuy.SetActive(Convert.ToInt16(value) == 1);

            //刷新card
            string subType = ItemData.GetValueOrDefault("subType", null);
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
                cardImage.rectTransform.sizeDelta =
                    new Vector2(cardImage.sprite.rect.width * 0.65f, cardImage.sprite.rect.height * 0.65f);
            //数量
            string count = ItemData.GetValueOrDefault("num", 1);
            countLabel.text = string.Concat("x", count);


            //货币
            string costGold = ItemData.GetValueOrDefault("costGold", 1);
            string costGem = ItemData.GetValueOrDefault("costGem", 1);
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
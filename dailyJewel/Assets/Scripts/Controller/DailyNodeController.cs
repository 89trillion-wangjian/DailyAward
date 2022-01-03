using System;
using Entity;
using Model;
using SimpleJSON;
using UnityEngine;
using Utils;
using View;
using EventType = Entity.EventType;

namespace Controller
{
    public class DailyNodeController : MonoBehaviour
    {

        [SerializeField] private DailyNodeView view;
    
        public static DailyNodeController Singleton;
    
        private JSONNode itemData;
    
        private int rewardType = 0;

        private int needCoin = 0;
        public void Awake()
        {
            Singleton = this;
        }

        public void InitData(JSONNode jsonNode)
        {
            this.itemData = jsonNode;
            InitDisplay();
        }

        public void BuyCard()
        {
            if (DailyModel.CreateInstance().MyCoinCount < needCoin)
            {
                EventCenter.PostEvent(EventType.ShowToask, "金币不足");
                return;
            }

            //扣金币
            DailyModel.CreateInstance().MyCoinCount -= needCoin;
        
            itemData["isPurchased"] = "1";
            FreshDisplay();
            if (rewardType == (int) RewardType.Diamonds)
            {
                string coinNum = itemData.GetValueOrDefault("num", 1);
                DailyModel.CreateInstance().MyCoinCount += Convert.ToInt32(coinNum);
            }
        }
    
        private void FreshDisplay()
        {
            string value = itemData.GetValueOrDefault("isPurchased", 1);
            view.ChangeBuyStatus(Convert.ToInt16(value) == -1);
        }
    
        private void InitDisplay()
        {
            string type = itemData.GetValueOrDefault("type", 1);
            rewardType = Convert.ToInt32(type);
            string value = itemData.GetValueOrDefault("isPurchased", 1);
            view.ChangeBuyStatus(Convert.ToInt16(value) == -1);
        
            //刷新card
            string subType = itemData.GetValueOrDefault("subType", null);
            view.ChangeCardImage(subType);

            //数量
            string count = itemData.GetValueOrDefault("num", 1);
            view.ShowCount(count);

            //货币
            string costGold = itemData.GetValueOrDefault("costGold", 1);
            string costGem = itemData.GetValueOrDefault("costGem", 1);
            needCoin = int.Parse(costGold);
            if (Convert.ToInt64(costGold) > 0)
            {
                view.ShowCoin(costGold);
            }
            else if (Convert.ToInt64(costGem) > 0)
            {
                view.ShowCoin(costGem);
            }
            else
            {
                view.ShowCoin("免费");
            }
        }
    }
}

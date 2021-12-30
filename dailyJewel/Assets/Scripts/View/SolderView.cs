using System;
using Model;
using UnityEngine;
using Utils;

namespace View
{
    public class SolderView : MonoBehaviour
    {
        public void GetAward()
        {
            ++GameModel.CreateInstance().SolderBuyTimes;
            var createCoinNum = Math.Min(15, GameModel.CreateInstance().SolderBuyTimes * 5);
            MainView.Singleton.CreateCoin(createCoinNum);
            EventCenter.PostEvent(Entity.EventType.FreshCoinCount, GameModel.CreateInstance().SolderBuyTimes * 5);
        }
    }
}
using Model;
using UnityEngine;
using Utils;
using View;

namespace Controller
{
    public class MyAssetsController : MonoBehaviour
    {
        public void Awake()
        {
            EventCenter.AddListener<int>(Entity.EventType.FreshCoinCount, RefreshCoinCount);
        }

        /// <summary>
        /// 刷新金币数量
        /// </summary>
        /// <param name="coinValue"></param>
        private void RefreshCoinCount(int coinValue)
        {
            MyAssetsView.Singleton.ShowCoinChange(MyAssetsView.Singleton.coinNumLabel,
                DailyModel.CreateInstance().MyCoinCount);
        }

        public void OnDestroy()
        {
            EventCenter.RemoveListener<int>(Entity.EventType.FreshCoinCount, RefreshCoinCount);
        }
    }
}
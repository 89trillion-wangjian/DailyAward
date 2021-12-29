using System;
using System.Collections;
using Controller;
using Model;
using SimpleJSON;
using UnityEngine;

namespace View
{
    public class MainView : MonoBehaviour
    {
        [SerializeField] private GameObject dailyJewel;

        [SerializeField] private DailyJuwelView dailyJuwelView;

        [SerializeField] private Sprite[] coinImages;

        [SerializeField] private GameObject prefabCoin;

        [SerializeField] private MainCtrl mainCtrl;

        private int coinCount;

        private int coinIndex;

        private readonly int maxCoin = 15;

        /// <summary>
        /// 读取json数据，成功后打开宝箱页面
        /// </summary>
        public void ReadJson()
        {
            mainCtrl.ReadJson();
        }

        public void ShowDailyPanel(JSONNode str)
        {
            dailyJewel.SetActive(true);
            dailyJuwelView.RanderItem(str);
        }

        public void CloseView()
        {
            dailyJewel.SetActive(false);
        }

        public void CreateCoin()
        {
            int createNum = Math.Min(5, maxCoin - coinCount);
            StartCoroutine(Create(createNum));
        }

        IEnumerator Create(int creatCount)
        {
            int i = 0;
            while (i < creatCount)
            {
                i++;
                GameObject coin = Instantiate(prefabCoin);
                if (gameObject != null) coin.transform.SetParent(gameObject.transform, false);
                coinCount++;
                PlayCoinView.singleton.ChangeImage(coinImages[i % 6]);
                yield return new WaitForSeconds(0.1f);
            }
        }


        public void ReduceCoin()
        {
            coinCount--;
        }
    }
}
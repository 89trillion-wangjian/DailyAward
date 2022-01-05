using System;
using System.Collections;
using Model;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Serialization;
using Utils;
using EventType = Entity.EventType;

namespace View
{
    public class DailyView : MonoBehaviour
    {
        [SerializeField] private GameObject dailyJewel;

        [FormerlySerializedAs("dailyJuwelView")] [SerializeField] private DailyJewelView dailyJewelView;

        [SerializeField] private Sprite[] coinImages;

        [SerializeField] private GameObject prefabCoin;

        [SerializeField] private GameObject toast;

        void Start()
        {
            DailyModel.CreateInstance().OnCoinAni += CreateCoin;
            EventCenter.AddListener<string>(EventType.ShowToask, ShowToast);
        }

        /// <summary>
        /// 打开每日精选 宝箱界面
        /// </summary>
        /// <param name="json">列表数据</param>
        public void ShowDailyPanel(JSONNode json)
        {
            dailyJewel.SetActive(true);
            dailyJewelView.RenderItem(json);
        }

        /// <summary>
        /// 创建金币动画
        /// </summary>
        /// <param name="createCoinNum"></param>
        private void CreateCoin(int createCoinNum = 5)
        {
            createCoinNum = Math.Min(createCoinNum, 15);
            StartCoroutine(Create(createCoinNum));
        }

        IEnumerator Create(int creatCount)
        {
            int i = 0;
            while (i < creatCount)
            {
                i++;
                Instantiate(prefabCoin, gameObject.transform, false);
                PlayCoinView.Singleton.ChangeImage(coinImages[i % 6]);
                yield return new WaitForSeconds(0.1f);
            }
        }

        public void ClosePanel()
        {
            dailyJewel.SetActive(false);
        }

        /// <summary>
        /// 提示
        /// </summary>
        public void ShowToast(string toastTxt)
        {
            Instantiate(toast, this.transform, false);
            ToastView.Singleton.ChangeToast(toastTxt);
        }
    }
}
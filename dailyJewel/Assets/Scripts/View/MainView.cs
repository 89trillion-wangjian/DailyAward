using System.Collections;
using Controller;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Serialization;

namespace View
{
    public class MainView : MonoBehaviour
    {
        [SerializeField] private GameObject dailyJewel;

        [SerializeField] private DailyJuwelView dailyJuwelView;

        [SerializeField] private Sprite[] coinImages;

        [SerializeField] private GameObject prefabCoin;

        [SerializeField] private MainController mainController;

        [SerializeField] private GameObject toast;

        public static MainView Singleton;

        private int coinIndex;

        public void Awake()
        {
            Singleton = this;
        }

        /// <summary>
        /// 点击按钮，读取json数据，成功后打开宝箱页面
        /// </summary>
        public void ReadJson()
        {
            mainController.ReadJson();
        }
        
        /// <summary>
        /// 打开宝箱页面
        /// </summary>
        /// <param name="str">数据</param>
        public void ShowDailyPanel(JSONNode str)
        {
            dailyJewel.SetActive(true);
            dailyJuwelView.RanderItem(str);
        }

        public void CloseView()
        {
            dailyJewel.SetActive(false);
        }
        
        /// <summary>
        /// 创建金币动画
        /// </summary>
        /// <param name="createCoinNum"></param>
        public void CreateCoin(int createCoinNum = 5)
        {
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
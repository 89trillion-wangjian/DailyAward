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

        [FormerlySerializedAs("mainCtrl")] [SerializeField] private MainController mainController;

        [SerializeField] private GameObject toast;

        public static MainView Singleton;

        private int coinCount;

        private int coinIndex;

        public void Awake()
        {
            Singleton = this;
        }

        /// <summary>
        /// 读取json数据，成功后打开宝箱页面
        /// </summary>
        public void ReadJson()
        {
            mainController.ReadJson();
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
                coinCount++;
                PlayCoinView.Singleton.ChangeImage(coinImages[i % 6]);
                yield return new WaitForSeconds(0.1f);
            }
        }


        public void ReduceCoin()
        {
            coinCount--;
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
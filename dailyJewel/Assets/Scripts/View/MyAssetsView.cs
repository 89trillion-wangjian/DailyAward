using System.Collections;
using Model;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class MyAssetsView : MonoBehaviour
    {

        public Text coinNumLabel;

        public static MyAssetsView Singleton;

        public GameObject coinImg;

        public void Awake()
        {
            Singleton = this;
        }

        public void Start()
        {
            DailyModel.CreateInstance().OnCoinChange += ChangeCount;
            coinNumLabel.text = DailyModel.CreateInstance().MyCoinCount.ToString();
        }

        public void ChangeCount(int value)
        {
            this.ShowCoinChange(coinNumLabel, DailyModel.CreateInstance().MyCoinCount);
        }

        public void ShowCoinChange(Text coinText, int coinValue, int changeCount = 10, float spaceTime = 0.1f)
        {
            StopAllCoroutines();
            StartCoroutine(ShowCoinAni(coinText, coinValue, changeCount, spaceTime));
        }

        IEnumerator ShowCoinAni(Text coinText, int coinValue, int changeCount, float spaceTime)
        {
            float lastGoldCount = 0;
            if (!string.IsNullOrEmpty(coinText.text))
            {
                try
                {
                    lastGoldCount = System.Convert.ToInt32(coinText.text);
                }
                catch (System.Exception e)
                {
                    Debug.Log(e);
                }
            }

            var onceAddCount = 1.0f / changeCount * (coinValue - lastGoldCount);
            var i = 0;
            while (i < changeCount)
            {
                i++;
                lastGoldCount += onceAddCount;
                coinText.text = ((int) lastGoldCount).ToString();
                yield return new WaitForSeconds(spaceTime);
            }

            coinText.text = coinValue.ToString();
        }
    }
}
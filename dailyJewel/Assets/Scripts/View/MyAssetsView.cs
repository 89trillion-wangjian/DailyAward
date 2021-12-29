using System.Collections;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class MyAssetsView : MonoBehaviour
    {
        [SerializeField] private Text coinNumLabel;

        private int myCoins;

        public void AddCoins(int coinValue)
        {
            myCoins += coinValue;
            ShowCoin(coinNumLabel, this.myCoins);
        }

        private void ShowCoin(Text coinText, int coinValue, int changeCount = 10, float spaceTime = 0.1f)
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
                coinText.text = lastGoldCount.ToString(CultureInfo.CurrentCulture);
                yield return new WaitForSeconds(spaceTime);
            }

            coinText.text = coinValue.ToString();
        }
    }
}
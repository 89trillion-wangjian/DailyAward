using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class MyAssetsView : MonoBehaviour
    {
        // Start is called before the first frame update
        public Text coinNumLabel;

        private int myCoins;
        // private int myDiamonds;

        public void AddCoins(int coinValue)
        {
            Debug.Log("调用加金币");
            this.myCoins += coinValue;
            this.ShowCoin(coinNumLabel, this.myCoins);
        }

        // public void AddDiamonds(int diaValue)
        // {
        //     this.myDiamonds += diaValue;
        //     this.ShowCoin(coinNumLabel, this.myCoins, 10, 0.1f);
        // }

        // Update is called once per frame

        public void ShowCoin(Text coinText, int coinValue, int changeCount = 10, float spaceTime = 0.1f)
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

            float onceAddCount = 1.0f / changeCount * (coinValue - lastGoldCount);
            int i = 0;
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
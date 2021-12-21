using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyAssetsCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    public Text coinNumLabel;

    public int myCoins = 0;
    public int myDiamonds = 0;
    void Start()
    {
        //ShowCoin(coinNumLabel, 300, 20, 0.05f );
    }

    public void AddCoins(int coinValue)
    {
        Debug.Log("调用加金币");
        this.myCoins += coinValue;
        this.ShowCoin(coinNumLabel, this.myCoins, 10, 0.1f);
        
    }

    public void AddDiamonds(int diaValue)
    {
        this.myDiamonds += diaValue;
        this.ShowCoin(coinNumLabel, this.myCoins, 10, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
    }

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


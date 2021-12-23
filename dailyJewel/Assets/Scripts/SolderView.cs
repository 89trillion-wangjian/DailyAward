using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolderView : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBtnClick()
    {
        GameObject myAssets;
        myAssets = GameObject.Find("Canvas");
        myAssets.SendMessage("CreateCoin");
        
        string coinNum;
        GameObject myAssetsCoin;
        myAssets = GameObject.Find("Canvas/dailyJewel/myAssets");
        Debug.Log(myAssets);
        myAssets.SendMessage("AddCoins", 5);
        
    }
}

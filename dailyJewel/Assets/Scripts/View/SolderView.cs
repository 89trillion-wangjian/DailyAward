using UnityEngine;

namespace View
{
    public class SolderView : MonoBehaviour
    {
        public void OnBtnClick()
        {
            GameObject myAssets;
            myAssets = GameObject.Find("Canvas");
            myAssets.SendMessage("CreateCoin");

            GameObject myAssetsCoin;
            myAssetsCoin = GameObject.Find("Canvas/dailyJewel/myAssets");
            myAssetsCoin.SendMessage("AddCoins", 5);
        }
    }
}
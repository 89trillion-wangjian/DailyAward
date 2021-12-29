using UnityEngine;

namespace View
{
    public class SolderView : MonoBehaviour
    {
        public void OnBtnClick()
        {
            var myAssets = GameObject.Find("Canvas");
            myAssets.SendMessage("CreateCoin");

            var myAssetsCoin = GameObject.Find("Canvas/dailyJewel/myAssets");
            myAssetsCoin.SendMessage("AddCoins", 5);
        }
    }
}
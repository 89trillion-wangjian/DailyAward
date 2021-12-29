using UnityEngine;

namespace View
{
    public class SolderView : MonoBehaviour
    {
        public void GetAward()
        {
            MainView.Singleton.CreateCoin();
            MyAssetsView.Singleton.AddCoins(5);
        }
    }
}
using Model;
using UnityEngine;

namespace Controller
{
    public class DailySolderController : MonoBehaviour
    {
        public void ReceiveAward()
        {
            DailyModel.CreateInstance().SolderBuyTimes++;
            DailyModel.CreateInstance().MyCoinCount = DailyModel.CreateInstance().MyCoinCount
                                                      + DailyModel.CreateInstance().SolderBuyTimes * 5;
        }
    }
}
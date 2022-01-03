using System.Collections;
using System.Collections.Generic;
using Model;
using UnityEngine;

public class DailySolderController : MonoBehaviour
{
    public void GetAward()
    {
        DailyModel.CreateInstance().SolderBuyTimes++;
        DailyModel.CreateInstance().MyCoinCount = DailyModel.CreateInstance().MyCoinCount
                                                  + DailyModel.CreateInstance().SolderBuyTimes * 5;
    }
}

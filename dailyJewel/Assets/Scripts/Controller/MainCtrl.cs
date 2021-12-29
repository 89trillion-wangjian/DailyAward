using System;
using System.IO;
using SimpleJSON;
using UnityEngine;
using View;

namespace Controller
{
    public class MainCtrl : MonoBehaviour
    {
        
        [SerializeField] private MainView mainView;
        
       /// <summary>
       ///  读取json数据
       /// </summary>
        public void ReadJson()
        {
            string path = String.Concat(Application.dataPath, "/Data/data.json" );
            string str = new StreamReader(path).ReadToEnd();
            try
            {
                var simpleJson = JSON.Parse(str);
                mainView.ShowDailyPanel(simpleJson["dailyProduct"]);
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }
    }
}
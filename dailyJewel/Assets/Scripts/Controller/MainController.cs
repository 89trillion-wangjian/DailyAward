using System;
using System.IO;
using SimpleJSON;
using UnityEngine;
using Utils;
using View;

namespace Controller
{
    public class MainController : MonoBehaviour
    {
        [SerializeField] private MainView mainView;

        public void Awake()
        {
            EventCenter.AddListener<string>(Entity.EventType.ShowToask, ShowToast);
        }

        /// <summary>
        ///  读取json数据
        /// </summary>
        public void ReadJson()
        {
            string path = $"{Application.dataPath}/Data/data.json";
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

        private void ShowToast(string toast)
        {
            mainView.ShowToast(toast);
        }
    }
}
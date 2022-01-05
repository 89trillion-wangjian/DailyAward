using System;
using System.IO;
using SimpleJSON;
using UnityEngine;
using View;

namespace Controller
{
    public class DailyController : MonoBehaviour
    {
        [SerializeField] private DailyView view;

        /// <summary>
        /// 点击按钮，读取json数据，成功后打开宝箱页面
        /// </summary>
        public void ShowDailyPanel()
        {
            JSONNode jsonData = ReadJson();
            if (jsonData == null)
            {
                return;
            }
            view.ShowDailyPanel(jsonData);
        }

        public void ClosePanel()
        {
            view.ClosePanel();
        }

        /// <summary>
        ///  读取json数据
        /// </summary>
        private JSONNode ReadJson()
        {
            string path = $"{Application.dataPath}/Data/data.json";
            string str = new StreamReader(path).ReadToEnd();
            try
            {
                var simpleJson = JSON.Parse(str);
                return simpleJson["dailyProduct"];
            }
            catch (Exception e)
            {
                Debug.Log(e);
                return null;
            }
        }
    }
}
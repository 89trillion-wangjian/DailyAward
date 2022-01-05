﻿using System;
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
            ReadJson();
        }

        public void ClosePanel()
        {
            view.ClosePanel();
        }

        /// <summary>
        ///  读取json数据
        /// </summary>
        private void ReadJson()
        {
            string path = $"{Application.dataPath}/Data/data.json";
            string str = new StreamReader(path).ReadToEnd();
            try
            {
                var simpleJson = JSON.Parse(str);
                view.ShowDailyPanel(simpleJson["dailyProduct"]);
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }
    }
}
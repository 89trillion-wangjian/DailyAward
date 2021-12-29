using System;
using System.IO;
using SimpleJSON;
using UnityEngine;
using View;

namespace Controller
{
    public class MainCtrl : BaseController
    {
        private MainView view;

        public override void Execute(string eventName, object data)
        {
            this.view = this.GetView<MainView>();
            Debug.Log("controller接受到" + this.view.Name);
            switch (eventName)
            {
                case "StartUp":
                {
                    JSONNode json = ReadJson();
                    this.view.OnGetRender(json);
                    break;
                }
            }
        }

        /**
         * 读取json
         */
        private JSONNode ReadJson()
        {
            string path = String.Concat(Application.dataPath,"/Data/data.json" );
            StreamReader streamReader = new StreamReader(path);
            string str = streamReader.ReadToEnd();
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
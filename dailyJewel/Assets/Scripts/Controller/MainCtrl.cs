using System;
using System.Collections;
using System.IO;
using SimpleJSON;
using UnityEngine;
using UnityEngine.UI;
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
                case "Init":
                {
                    break;
                }
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
            StreamReader streamReader = new StreamReader(Application.dataPath + "/Data/data.json");
            string str = streamReader.ReadToEnd();
            //json = JsonMapper.ToObject(str);
            //JsonData jsonJemp = new JsonData();
            //JSONNode jsonNode = new JSONString(str);
            try
            {
                var simpleJson = JSON.Parse(str);
                //jsonJemp = JsonUtility.FromJson<JsonData>(Application.dataPath + "/data/data.json");
                //Debug.Log(jsonJemp.dailyProduct);
                //Debug.Log(simpleJson["dailyProduct"]);
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
using System;
using System.Collections;
using Controller;
using Model;
using SimpleJSON;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class MainView : BaseView
    {
        [SerializeField] public GameObject dailyJewel;
        [SerializeField] private DailyJuwelView dailyJuwelView;
        [SerializeField] public Sprite[] coinImages;
        [SerializeField] public GameObject prefabCoin;
        [SerializeField] private MainView mainView;
        private int coinCount;
        private int coinIndex;
        private readonly int maxCoin = 15;

        void Start()
        {
            RegisterView(mainView);
            GameModel model = new GameModel();
            MVC.RegisterModel(model);

            RegisterController(Consts.StartUp, typeof(MainCtrl));
        }

        /**
        * 按钮点击
         */
        public void OnBtnClick()
        {
            SendEvent(Consts.StartUp);
        }

        public void OnGetRender(JSONNode str)
        {
            dailyJewel.SetActive(true);
            dailyJuwelView.GetDataRender(str);
        }

        public void OnBtnClose()
        {
            dailyJewel.SetActive(false);
        }

        public void CreateCoin()
        {
            int createNum = Math.Min(5, maxCoin - coinCount);
            StartCoroutine(Create(createNum));

            SendEvent(Consts.Createcoin);
        }

        IEnumerator Create(int creatCount)
        {
            int i = 0;
            while (i < creatCount)
            {
                i++;
                GameObject coin = Instantiate(prefabCoin);
                if (gameObject != null) coin.transform.SetParent(gameObject.transform, false);
                coinCount++;
                Image image = coin.GetComponent<Image>();
                image.sprite = coinImages[i % 6];
                image.rectTransform.sizeDelta =
                    new Vector2(image.sprite.rect.width * 0.7f, image.sprite.rect.height * 0.7f);
                yield return new WaitForSeconds(0.1f);
            }
        }
        

        public void ReduceCoin()
        {
            coinCount--;
        }


        // Update is called once per frame
        public override string Name { get; } = "MainView";

        public override void HandleEvent(string str, object data)
        {
            throw new NotImplementedException();
        }

        public void RegisterController(string eventName, Type controllerType)
        {
            MVC.RegisterController(eventName, controllerType);
        }

        public void RegisterView(BaseView viewName)
        {
            MVC.RegisterView(viewName);
        }

        /// <summary>
        /// 发送事件
        /// </summary>
        protected new void SendEvent(string eventName, object data = null)
        {
            MVC.SendEvent(eventName, data);
        }
    }


    public static class Consts
    {
        public static string StartUp = "StartUp";
        public static string Createcoin = "Createcoin";
    }
}
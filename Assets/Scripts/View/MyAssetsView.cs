﻿using System;
using DG.Tweening;
using Model;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class MyAssetsView : MonoBehaviour
    {
        public Text coinNumLabel;

        public static MyAssetsView Singleton;

        public GameObject coinImg;

        private float coinNum;
        
        private Sequence mScoreSequence;

        public void Awake()
        {
            Singleton = this;
        }

        public void Start()
        {
            DailyModel.CreateInstance().OnCoinChange += ChangeCount;
            coinNumLabel.text = DailyModel.CreateInstance().MyCoinCount.ToString();
            coinNum = System.Convert.ToInt32(coinNumLabel.text);
        }

        private void ChangeCount(int nowCoinCount)
        {
            mScoreSequence = DOTween.Sequence();
            mScoreSequence.SetAutoKill(false);
            mScoreSequence.SetDelay(0.5f);
            mScoreSequence.Append(DOTween.To(delegate (float value) {
                var temp = Math.Floor(value);
                coinNumLabel.text = temp + "";
            }, coinNum, nowCoinCount, 0.4f));
            coinNum = nowCoinCount;
        }

    }
}
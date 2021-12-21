using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SimpleJSON;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DailyNodeView : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject btnBuy;
    public GameObject hasBuy;

    public Image cardImage;
    public Text cardColdLabel;
    public GameObject moneyImage;
    public Text countLabel;
    
    public Sprite[] Sprites;

    private int rewardType;

    public JSONNode itemData;

    
    void Start()
    {
        
    }

    public void OnBtnBuy()
    {
        this.itemData["isPurchased"] = "1";
        this.FreshDisplay();
        if (rewardType == (int)RewardType.Coins)
        {
            //itemData.TryGetValue("num", out coinNum);
            string coinNum = itemData.GetValueOrDefault("num", 1);
            GameObject myAssets;
            myAssets = GameObject.Find("Canvas/dailyJewel/myAssets");
            Debug.Log(myAssets);
            myAssets.SendMessage("AddCoins", Convert.ToInt32(coinNum));
           // myAssets.GetComponent<MyAssetsCtrl>().AddCoins(Convert.ToInt32(coinNum));
           
           GameObject myCanvas;
           myCanvas = GameObject.Find("Canvas");
           myCanvas.SendMessage("CreateCoin");
            
        }
        else if(rewardType == (int)RewardType.Diamonds)
        {
            string diaNum = itemData.GetValueOrDefault("num", 1);
            GameObject myAssets;
            myAssets = GameObject.Find("Canvas/dailyJewel/myAssets");
            Debug.Log(myAssets);
            myAssets.SendMessage("AddDiamonds", Convert.ToInt32(diaNum));
            
            GameObject myCanvas;
            myCanvas = GameObject.Find("Canvas");
            myCanvas.SendMessage("CreateCoin");
        }
    }


    public void InitData(JSONNode jsonNode)
    {
       //Debug.Log(idc);
        this.itemData = jsonNode;
        this.InitDisplay();
    }

    public void FreshDisplay()
    {
        string value = itemData.GetValueOrDefault("isPurchased", 1);
        btnBuy.SetActive(Convert.ToInt16(value) == -1);
        hasBuy.SetActive(Convert.ToInt16(value) == 1);
    }

    public void InitDisplay()
    {
        string type = itemData.GetValueOrDefault("type", 1);
        rewardType = Convert.ToInt32(type);
        string value = itemData.GetValueOrDefault("isPurchased", 1);
        btnBuy.SetActive(Convert.ToInt16(value) == -1);
        hasBuy.SetActive(Convert.ToInt16(value) == 1);
        
        //刷新card
        string subType = itemData.GetValueOrDefault("subType", null);
        Debug.Log(subType);
        Debug.Log("子类型");
        if (string.IsNullOrEmpty(subType))
        {
            float randow = Random.Range(0, 1.0f);
            if (randow > 0.5)
            {
                cardImage.sprite = Resources.Load("awards/coin_1", typeof(Sprite)) as Sprite;
            }
            else
            {
                cardImage.sprite = Resources.Load("awards/diamond_2", typeof(Sprite)) as Sprite;
               
            }
        }
        else
        {
            cardImage.sprite = Resources.Load("cards/" + subType, typeof(Sprite)) as Sprite;
        }
        cardImage.rectTransform.sizeDelta = new Vector2(cardImage.sprite.rect.width * 0.65f,cardImage.sprite.rect.height * 0.65f);
        //数量
        string count = itemData.GetValueOrDefault("num", 1);
        countLabel.text = count;
        
        
        
        //货币
        string costGold = itemData.GetValueOrDefault("costGold", 1);
        string costGem = itemData.GetValueOrDefault("costGem", 1);
        if (Convert.ToInt64(costGold) > 0)
        {
            cardColdLabel.text = costGold;
        }
        else if(Convert.ToInt64(costGem) > 0)
        {
            cardColdLabel.text = costGem;
        }
        else
        {
            moneyImage.SetActive(false);
            cardColdLabel.text = "免费";
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}


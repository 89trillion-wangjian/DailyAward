using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJSON;
using UnityEngine.UI;
using Object = System.Object;

public class MainView : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]public GameObject dailyJewel;

    [SerializeField]public Sprite[] coinImages;
    [SerializeField]public GameObject prefabCoin;
    
    private delegate void dlgCrossThread();
    //private dlgCrossThread DCT = new dlgCrossThread(playCoinAni);
    void Start()
    {
        
    }
    /**
     * 按钮点击
     */
    public void OnBtnClick()
    {
        JSONNode str = ReadJson();
        if (!string.IsNullOrEmpty(str))
        {
            return;
        }

        dailyJewel.SetActive(true);
        dailyJewel.GetComponent<DailyJuwelCtrl>().GetDataRender(str);
    }


    public JSONNode ReadJson()
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
            return null;
        }
        
    }

    public void OnBtnClose()
    {
        dailyJewel.SetActive(false);
    }

    private int coinCount = 0;
    private int coinIndex;
    private int maxCoin = 15;
    public void CreateCoin()
    {
        int createNum = Math.Min(5, maxCoin - coinCount);
        //Debug.Log(maxCoin);
        //Debug.Log(coinCount);
        StartCoroutine(Create(createNum));
    }

    IEnumerator Create(int creatCount)
    {
        
        int i = 0;
        while (i < creatCount)
        {
            i++;
            GameObject coin = Instantiate(prefabCoin);
            coin.transform.SetParent( gameObject.transform, false);
            coinCount++;
            Image image = coin.GetComponent<Image>();
            image.sprite = coinImages[i % 6];
            image.rectTransform.sizeDelta = new Vector2(image.sprite.rect.width * 0.7f,image.sprite.rect.height * 0.7f);
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void ReduceCoin()
    {
        coinCount--;
    }
    



    // Update is called once per frame
    void Update()
    {
        
    }
}

public class JsonData
{
    [SerializeField]public List<DailyProduct> dailyProduct;
    [SerializeField]public int dailyProductCountDown;
}

public class DailyProduct
{
    [SerializeField]public int productId;
    [SerializeField]public int type;
    [SerializeField]public int subType;
    [SerializeField]public int num;
    [SerializeField]public int costGold;
    [SerializeField]public int costGem;
    [SerializeField]public int isPurchased;
}

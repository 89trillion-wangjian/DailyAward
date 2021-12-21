using System;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;
using UnityEngine.UI;

public class DailyJuwelCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dailyNode;
    public GameObject solderNode;

    public GameObject dailyItme;
    public GameObject dailyLockItem;
    public GameObject solderItem;
    void Start()
    {
        
    }

    public void GetDataRender(JSONNode jsonNode)
    {
        Debug.Log(jsonNode);
       //Double jsonHang = Math.Ceiling(5.0 / 3.0);
        //int total = Convert.ToInt16(jsonHang * 3.0);
        //int preCount = 5;
        
        
        Double jsonHang = Math.Ceiling(jsonNode.Count / 3.0);
        int preCount = jsonNode.Count;
        int total = Convert.ToInt32(jsonHang * 3.0);
        
        //IDictionary<string, string> idc = new Dictionary<string, string>();
        //idc.Add("productId", "1");
        //idc.Add("num", "25");
        //idc.Add("costGold", "0");
        //idc.Add("costGem", "0");
        //idc.Add("subType", "7");
        //idc.Add("isPurchased", "-1");

        if (this.dailyNode.transform.childCount > 0)
        {
            return;
        }

        for (var i = 0; i < total; i++)
        {   
            if (i >= preCount)
            {
                GameObject daily_lock = Instantiate(this.dailyLockItem);
                daily_lock.transform.SetParent(this.dailyNode.transform, false);
            }
            else
            {
                GameObject daily = Instantiate(this.dailyItme);
                daily.transform.SetParent(this.dailyNode.transform, false);
                daily.GetComponent<DailyNodeView>().InitData(jsonNode[i]);
            }
        }
        //for (int i = 0; i < total; i++)
        //{
            
            //if (i >= preCount)
            //{
                //GameObject daily_lock = Instantiate(this.dailyLockItem);
              //  daily_lock.transform.SetParent(this.dailyNode.transform, false);
            //}
            //else
            //{
                //GameObject daily = Instantiate(this.dailyItme);
              //  daily.transform.SetParent(this.dailyNode.transform, false);
            //    daily.GetComponent<DailyNodeCtrl>().initData(idc);
          //  }
        //}
        LayoutRebuilder.ForceRebuildLayoutImmediate((this.dailyNode.transform as RectTransform));
        
        for (int j = 0; j < 3; j++)
        {
            GameObject daily = Instantiate(this.solderItem);
            daily.transform.SetParent(this.solderNode.transform, false);
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate((this.solderNode.transform as RectTransform));
        
        
        

        //Debug.Log(JsonUtility.ToJson(jsonData));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

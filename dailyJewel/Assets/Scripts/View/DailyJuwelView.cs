using System;
using Model;
using SimpleJSON;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class DailyJuwelView : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] public GameObject dailyNode;
        [SerializeField] public GameObject solderNode;

        [SerializeField] public GameObject dailyItme;
        [SerializeField] public GameObject dailyLockItem;
        [SerializeField] public GameObject solderItem;


        public void GetDataRender(JSONNode jsonNode)
        {
            Double jsonHang = Math.Ceiling(jsonNode.Count / 3.0);
            int preCount = jsonNode.Count;
            int total = Convert.ToInt32(jsonHang * 3.0);
            GameModel.CreateInstance().JsonNode = jsonNode;
            if (this.dailyNode.transform.childCount > 0)
            {
                return;
            }

            for (var i = 0; i < total; i++)
            {
                if (i >= preCount)
                {
                    Instantiate(this.dailyLockItem, this.dailyNode.transform, false);
                }
                else
                {
                    Instantiate(this.dailyItme, this.dailyNode.transform, false);
                    DailyNodeView.Singleton.InitData(jsonNode[i]);
                }
            }

            LayoutRebuilder.ForceRebuildLayoutImmediate((this.dailyNode.transform as RectTransform));

            Instantiate(this.solderItem, this.solderNode.transform, false);
            LayoutRebuilder.ForceRebuildLayoutImmediate((this.solderNode.transform as RectTransform));
        }
    }
}
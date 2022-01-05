using System;
using Controller;
using SimpleJSON;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class DailyJewelView : MonoBehaviour
    {
        [SerializeField] private GameObject dailyNode;

        [SerializeField] private GameObject solderNode;

        [SerializeField] private GameObject dailyItem;

        [SerializeField] private GameObject dailyLockItem;

        [SerializeField] private GameObject solderItem;

        /// <summary>
        /// 渲染卡牌奖励和士兵招募宝箱
        /// </summary>
        /// <param name="jsonNode"></param>
        public void RenderItem(JSONNode jsonNode)
        {
            Double jsonHang = Math.Ceiling(jsonNode.Count / 3.0);
            int preCount = jsonNode.Count;
            int total = Convert.ToInt32(jsonHang * 3.0);
            if (dailyNode.transform.childCount > 0)
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
                    Instantiate(this.dailyItem, this.dailyNode.transform, false);
                    DailyNodeController.Singleton.InitData(jsonNode[i]);
                }
            }

            LayoutRebuilder.ForceRebuildLayoutImmediate((this.dailyNode.transform as RectTransform));

            Instantiate(this.solderItem, this.solderNode.transform, false);
            LayoutRebuilder.ForceRebuildLayoutImmediate((this.solderNode.transform as RectTransform));
        }
    }
}
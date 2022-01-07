using Controller;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class DailyNodeView : MonoBehaviour
    {
        [SerializeField] private GameObject btnBuy;

        [SerializeField] private GameObject hasBuy;

        [SerializeField] private Image cardImage;

        [SerializeField] private Text cardColdLabel;

        [SerializeField] private GameObject moneyImage;

        [SerializeField] private Text countLabel;

        /// <summary>
        /// 切换状态
        /// </summary>
        /// <param name="isBuy"></param>
        public void ChangeBuyStatus(bool isBuy)
        {
            btnBuy.SetActive(isBuy);
            hasBuy.SetActive(!isBuy);
        }

        /// <summary>
        /// 购买按钮的货币
        /// </summary>
        /// <param name="txt"></param>
        /// <param name="buyType"></param>
        public void ShowNeedCoin(string txt, DailyNodeBuyType buyType)
        {
            if (buyType == DailyNodeBuyType.Free)
            {
                moneyImage.SetActive(false);
            }

            cardColdLabel.text = txt;
        }

        /// <summary>
        /// 显示数量
        /// </summary>
        /// <param name="count"></param>
        public void ShowCount(string count)
        {
            countLabel.text = $"x{count}";
        }

        public void ChangeCardImage(string subType)
        {
            cardImage.sprite
                = Resources.Load<Sprite>(string.IsNullOrEmpty(subType) ? "awards/coin_1" : $"cards/{subType}");

            if (cardImage.sprite != null)
            {
                cardImage.rectTransform.sizeDelta
                    = new Vector2(cardImage.sprite.rect.width * 0.65f, cardImage.sprite.rect.height * 0.65f);
            }
        }
    }
}
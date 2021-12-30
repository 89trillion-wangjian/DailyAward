using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class PlayCoinView : MonoBehaviour
    {
        [SerializeField] private Image image;

        private GameObject myAssets;

        private float waitTime;

        public static PlayCoinView Singleton;

        public void Awake()
        {
            Singleton = this;
        }

        public void Start()
        {
            myAssets = MyAssetsView.Singleton.coinImg;
            MoveCoin();
        }
        /// <summary>
        /// 金币动效
        /// </summary>
        private void MoveCoin()
        {
            transform.localScale = new Vector3(0, 0, 0);
            transform.DOScale(new Vector3(1, 1, 1), 0.1f).SetAutoKill(true);
            Tweener t = transform.DOMove(myAssets.transform.position, 0.3f).SetDelay(0.2f);
            t.onComplete = DestroyCoin;
        }

        private void DestroyCoin()
        {
            MainView.Singleton.ReduceCoin();
            Destroy(this.gameObject);
        }

        public void ChangeImage(Sprite sp)
        {
            image.sprite = sp;
            image.rectTransform.sizeDelta
                = new Vector2(image.sprite.rect.width * 0.7f, image.sprite.rect.height * 0.7f);
        }
    }
}
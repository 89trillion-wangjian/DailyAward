using DG.Tweening;
using UnityEngine;

namespace View
{
    public class PlayCoinView : MonoBehaviour
    {
        [SerializeField] private AnimationClip animClip;

        [SerializeField] private Animator animator;

        private GameObject myAssets;

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
            Destroy(this.gameObject);
        }

        public void ChangeImage(int index)
        {
            float element = animClip.length / 6.0f;
            animator.Play("createCoinAnim", -1, element * index);
            animator.speed = 0;
        }
    }
}
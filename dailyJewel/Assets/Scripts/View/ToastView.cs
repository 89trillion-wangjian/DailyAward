using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class ToastView : MonoBehaviour
    {
        [SerializeField] private Text toast;

        public static ToastView Singleton = null;

        public void Awake()
        {
            Singleton = this;
        }

        /// <summary>
        /// 更改toast提示文本
        /// </summary>
        /// <param name="toastTxt"></param>
        public void ChangeToast(string toastTxt)
        {
            toast.text = toastTxt;
        }

        public void Start()
        {
            Invoke(nameof(CloseToast), 2);
        }

        public void CloseToast()
        {
            Destroy(gameObject);
        }
    }
}
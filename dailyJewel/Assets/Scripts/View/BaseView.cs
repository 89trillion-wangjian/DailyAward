using System.Collections.Generic;
using Model;
using UnityEngine;

namespace View
{
    public abstract class BaseView : MonoBehaviour
    {
        //名字标识
        public abstract string Name { get; }

        /// <summary>
        /// 事件关心列表
        /// </summary>
        [HideInInspector] public List<string> attentionList = new List<string>();

        public virtual void RegisterAttentionEvent()
        {
        }

        /// <summary>
        /// 处理事件
        /// </summary>
        public abstract void HandleEvent(string str, object data);

        /// <summary>
        /// 发送事件
        /// </summary>
        protected void SendEvent(string eventName, object data = null)
        {
            MVC.SendEvent(eventName, data);
        }

        protected T GetModel<T>()
            where T : BaseModel
        {
            return MVC.GetModel<T>();
        }
    }
}
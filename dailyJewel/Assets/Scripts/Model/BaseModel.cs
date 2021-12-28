namespace Model
{
    public abstract class BaseModel
    {
        //名字标识
        public abstract string Name { get; }

        /// <summary>
        /// 发送事件
        /// </summary>
        protected void SendEvent(string eventName, object data = null)
        {
            MVC.SendEvent(eventName, data);
        }
    }
}
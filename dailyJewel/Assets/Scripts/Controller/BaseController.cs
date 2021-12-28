using System;
using Model;
using View;

namespace Controller
{
    public abstract class BaseController
    {
        public abstract void Execute(string eventName, object data);

        protected T GetModel<T>()
            where T : BaseModel
        {
            return MVC.GetModel<T>();
        }

        protected T GetView<T>()
            where T : BaseView
        {
            return MVC.GetView<T>();
        }

        /// <summary>
        /// 注册模型
        /// </summary>
        protected void RegisterModel(BaseModel model)
        {
            MVC.RegisterModel(model);
        }

        /// <summary>
        /// 注册视图
        /// </summary>
        protected void RegisterView(BaseView view)
        {
            MVC.RegisterView(view);
        }

        /// <summary>
        /// 注册controller
        /// </summary>
        protected void RegisterController(string eventName, Type controllerType)
        {
            MVC.RegisterController(eventName, controllerType);
        }
    }
}
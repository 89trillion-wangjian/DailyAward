using System.Collections.Generic;
using System;
using Controller;
using View;

public class MVC
{
    //资源
    public static Dictionary<string, BaseModel> Models = new Dictionary<string, BaseModel>();
    public static Dictionary<string, BaseView> Views = new Dictionary<string, BaseView>();
    public static Dictionary<string, Type> CommanMap = new Dictionary<string, Type>();

    /// <summary>
    /// 注册view
    /// </summary>
    /// <param name="view"></param>
    public static void RegisterView(BaseView view)
    {
        //防止view重复注册
        if (Views.ContainsKey(view.Name))
        {
            Views.Remove(view.Name);
        }

        view.RegisterAttentionEvent();
        Views[view.Name] = view;
    }

    /// <summary>
    /// 注册model
    /// </summary>
    /// <param name="model"></param>
    public static void RegisterModel(BaseModel model)
    {
        Models[model.Name] = model;
    }

    /// <summary>
    /// 注册controller
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="controllerType"></param>
    public static void RegisterController(string eventName, Type controllerType)
    {
        CommanMap[eventName] = controllerType;
    }

    /// <summary>
    /// 获取model
    /// </summary>
    /// <returns></returns>
    public static T GetModel<T>()
        where T : BaseModel
    {
        foreach (var m in Models.Values)
        {
            if (m is T)
            {
                return (T) m;
            }
        }

        return null;
    }

    /// <summary>
    /// 获取view
    /// </summary>
    /// <returns></returns>
    public static T GetView<T>()
        where T : BaseView
    {
        foreach (var v in Views.Values)
        {
            if (v is T)
            {
                return (T) v;
            }
        }

        return null;
    }

    public static void SendEvent(string eventName, object data = null)
    {
        //controller执行
        if (CommanMap.ContainsKey(eventName))
        {
            Type t = CommanMap[eventName];
            BaseController c = Activator.CreateInstance(t) as BaseController;
            c.Execute(eventName, data);
        }

        //view处理
        foreach (var v in Views.Values)
        {
            if (v.attentionList.Contains(eventName))
            {
                //执行
                v.HandleEvent(eventName, data);
            }
        }
    }
}
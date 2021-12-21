using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCenter
{
    public delegate void DelCallBack();
    
    public static Dictionary<dynamic, dynamic>  m_dDicEventType = new Dictionary<dynamic, dynamic>();
    
    public static void AddListener(EEventType eventType,DelCallBack handler)
    {
        if (!m_dDicEventType.ContainsKey(eventType))
        {
            m_dDicEventType.Add(eventType,null);
        }
        //m_dDicEventType[eventType] += handler;
    }
    
    public static void RemoveListener(EEventType eventType, DelCallBack handler)
    {
        if (m_dDicEventType.ContainsKey(eventType))
        {
            //m_dDicEventType[eventType] -= handler;
        }
    }
    
    public static void RemoveAllListener()
    {
        m_dDicEventType.Clear();
    }
    
    public static void Broadcast(EEventType eventType)
    {
        DelCallBack del;
        //if (m_dDicEventType.TryGetValue(eventType, out del))
        //{
          //  if (del!=null)
            //{
              //  del();
            //}
        //}
    }
    
}

public enum EEventType
{
   ADD_COINS,
}

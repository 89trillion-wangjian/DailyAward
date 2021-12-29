using System;
using System.Collections.Generic;

namespace Utils
{
    public class EventCenter
    {
        public delegate void EventHandle();

        public delegate void EventHandle<T>(T value);

        public delegate void EventHandle<T1, T2>(T1 value1, T2 value2);

        public delegate void EventHandle<T1, T2, T3>(T1 value1, T2 value2, T3 value3);

        private static Dictionary<string, Delegate> _eventHandles;

        /// <summary>
        /// 发送事件
        /// </summary>
        /// <param name="eventName">事件名</param>
        [Obsolete("已过时，请使用PostEvent函数")]
        public static void SendEvent(string eventName)
        {
            PostEvent(eventName);
        }

        /// <summary>
        /// 发送事件
        /// </summary>
        /// <param name="eventName">事件名</param>
        /// <param name="value">数据</param>
        [Obsolete("已过时，请使用PostEvent函数")]
        public static void SendEvent(string eventName, object value)
        {
            PostEvent(eventName, value);
        }

        /// <summary>
        /// 发送事件
        /// </summary>
        /// <param name="eventName">事件名</param>
        public static void PostEvent(string eventName)
        {
            if (_eventHandles == null) return;
            Delegate d;
            if (_eventHandles.TryGetValue(eventName, out d))
            {
                if (d == null) return;
                EventHandle call = d as EventHandle;
                if (call != null)
                {
                    call();
                }
                else if (d is EventHandle<object>)
                {
                    //兼容之前旧版本EgoEventCenter逻辑
                    EventHandle<object> call2 = d as EventHandle<object>;
                    call2(null);
                }
                else
                {
                    throw new Exception(string.Format("事件{0}包含着不同类型的委托", eventName));
                }
            }
        }

        /// <summary>
        /// 发送事件
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        public static void PostEvent<T>(string eventName, T value)
        {
            if (_eventHandles == null) return;
            Delegate d;
            if (_eventHandles.TryGetValue(eventName, out d))
            {
                if (d == null) return;
                EventHandle<T> call = d as EventHandle<T>;
                if (call != null)
                {
                    call(value);
                }
                else
                {
                    throw new Exception(string.Format("事件{0}包含着不同类型的委托{1}", eventName, d.GetType()));
                }
            }
        }

        /// <summary>
        /// 发送事件
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        public static void PostEvent<T1, T2>(string eventName, T1 value1, T2 value2)
        {
            if (_eventHandles == null) return;
            Delegate d;
            if (_eventHandles.TryGetValue(eventName, out d))
            {
                if (d == null) return;
                EventHandle<T1, T2> call = d as EventHandle<T1, T2>;
                if (call != null)
                {
                    call(value1, value2);
                }
                else
                {
                    throw new Exception(string.Format("事件{0}包含着不同类型的委托{1}", eventName, d.GetType()));
                }
            }
        }

        /// <summary>
        /// 发送事件
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="value3"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        public static void PostEvent<T1, T2, T3>(string eventName, T1 value1, T2 value2, T3 value3)
        {
            if (_eventHandles == null) return;
            Delegate d;
            if (_eventHandles.TryGetValue(eventName, out d))
            {
                if (d == null) return;
                EventHandle<T1, T2, T3> call = d as EventHandle<T1, T2, T3>;
                if (call != null)
                {
                    call(value1, value2, value3);
                }
                else
                {
                    throw new Exception(string.Format("事件{0}包含着不同类型的委托{1}", eventName, d.GetType()));
                }
            }
        }

        /// <summary>
        /// 监听事件
        /// </summary>
        /// <param name="eventName">事件名</param>
        /// <param name="handle">回调</param>
        public static void AddListener(string eventName, EventHandle handle)
        {
            OnListeningAdd(eventName, handle);
            _eventHandles[eventName] = (EventHandle) _eventHandles[eventName] + handle;
        }

        /// <summary>
        /// 监听事件
        /// </summary>
        /// <param name="eventName">事件名</param>
        /// <param name="handle">回调</param>
        public static void AddListener(string eventName, EventHandle<object> handle)
        {
            OnListeningAdd(eventName, handle);
            _eventHandles[eventName] = (EventHandle<object>) _eventHandles[eventName] + handle;
        }

        /// <summary>
        /// 监听事件
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="handle"></param>
        /// <typeparam name="T"></typeparam>
        public static void AddListener<T>(string eventName, EventHandle<T> handle)
        {
            OnListeningAdd(eventName, handle);
            _eventHandles[eventName] = (EventHandle<T>) _eventHandles[eventName] + handle;
        }

        /// <summary>
        /// 监听事件
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="handle"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        public static void AddListener<T1, T2>(string eventName, EventHandle<T1, T2> handle)
        {
            OnListeningAdd(eventName, handle);
            _eventHandles[eventName] = (EventHandle<T1, T2>) _eventHandles[eventName] + handle;
        }

        /// <summary>
        /// 监听事件
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="handle"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        public static void AddListener<T1, T2, T3>(string eventName, EventHandle<T1, T2, T3> handle)
        {
            OnListeningAdd(eventName, handle);
            _eventHandles[eventName] = (EventHandle<T1, T2, T3>) _eventHandles[eventName] + handle;
        }

        /// <summary>
        /// 移除事件监听
        /// </summary>
        /// <param name="eventName">事件名</param>
        /// <param name="handle">回调</param>
        [Obsolete("已过时，请使用RemoveListener函数")]
        public static void RemoveHandle(string eventName, EventHandle handle)
        {
            RemoveListener(eventName, handle);
        }

        /// <summary>
        /// 移除事件监听
        /// </summary>
        /// <param name="eventName">事件名</param>
        /// <param name="handle">回调</param>
        [Obsolete("已过时，请使用RemoveListener函数")]
        public static void RemoveHandle(string eventName, EventHandle<object> handle)
        {
            RemoveListener<object>(eventName, handle);
        }

        /// <summary>
        /// 移除事件监听
        /// </summary>
        /// <param name="eventName">事件名</param>
        /// <param name="handle">回调</param>
        public static void RemoveListener(string eventName, EventHandle handle)
        {
            if (_eventHandles == null)
            {
                return;
            }

            if (!_eventHandles.ContainsKey(eventName)) return;
            OnListeningRemove(eventName, handle);
            _eventHandles[eventName] = (EventHandle) _eventHandles[eventName] - handle;
        }

        /// <summary>
        /// 移除事件监听
        /// </summary>
        /// <param name="eventName">事件名</param>
        /// <param name="handle">回调</param>
        public static void RemoveListener(string eventName, EventHandle<object> handle)
        {
            RemoveListener<object>(eventName, handle);
        }

        /// <summary>
        /// 移除事件监听
        /// </summary>
        /// <param name="eventName">事件名</param>
        /// <param name="handle"></param>
        public static void RemoveListener<T>(string eventName, EventHandle<T> handle)
        {
            if (_eventHandles == null)
            {
                return;
            }

            if (!_eventHandles.ContainsKey(eventName)) return;
            OnListeningRemove(eventName, handle);
            _eventHandles[eventName] = (EventHandle<T>) _eventHandles[eventName] - handle;
        }

        /// <summary>
        /// 移除事件监听
        /// </summary>
        /// <param name="eventName">事件名</param>
        /// <param name="handle"></param>
        public static void RemoveListener<T1, T2>(string eventName, EventHandle<T1, T2> handle)
        {
            if (_eventHandles == null)
            {
                return;
            }

            if (!_eventHandles.ContainsKey(eventName)) return;
            OnListeningRemove(eventName, handle);
            _eventHandles[eventName] = (EventHandle<T1, T2>) _eventHandles[eventName] - handle;
        }

        /// <summary>
        /// 移除事件监听
        /// </summary>
        /// <param name="eventName">事件名</param>
        /// <param name="handle"></param>
        public static void RemoveListener<T1, T2, T3>(string eventName, EventHandle<T1, T2, T3> handle)
        {
            if (_eventHandles == null)
            {
                return;
            }

            if (!_eventHandles.ContainsKey(eventName)) return;
            OnListeningRemove(eventName, handle);
            _eventHandles[eventName] = (EventHandle<T1, T2, T3>) _eventHandles[eventName] - handle;
        }


        static void OnListeningAdd(string eventName, Delegate callback)
        {
            if (_eventHandles == null)
                _eventHandles = new Dictionary<string, Delegate>();
            if (!_eventHandles.ContainsKey(eventName))
            {
                _eventHandles.Add(eventName, null);
            }

            Delegate d = _eventHandles[eventName];
            if (d != null && d.GetType() != callback.GetType())
            {
                throw new Exception(string.Format("尝试添加两种不同类型的委托,委托1为{0}，委托2为{1}", d.GetType(), callback.GetType()));
            }
        }

        static void OnListeningRemove(string eventName, Delegate callback)
        {
            if (_eventHandles.ContainsKey(eventName))
            {
                Delegate d = _eventHandles[eventName];
                if (d != null && d.GetType() != callback.GetType())
                {
                    throw new Exception(string.Format("尝试移除不同类型的事件，事件名{0},已存储的委托类型{1},当前事件委托{2}", eventName,
                        d.GetType(),
                        callback.GetType()));
                }
            }
            else
            {
                throw new Exception(string.Format("没有事件名{0}", eventName));
            }
        }
    }
}
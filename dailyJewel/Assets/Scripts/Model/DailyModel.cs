using SimpleJSON;

namespace Model
{
    public class DailyModel
    {
        public delegate void OnOpenPanel<in T>(T value);

        private int myCoinCount;

        public OnValueChange OnCoinChange;

        public OnValueChange OnCoinAni;

        public int SolderBuyTimes { get; set; }

        /// 模型委托（当用户信息发生变化时执行）
        public delegate void OnValueChange(int val);

        public OnOpenPanel<JSONNode> OpenPanel;

        //单例
        private static DailyModel Singleton = null;

        public static DailyModel CreateInstance()
        {
            return Singleton ?? (Singleton = new DailyModel());
        }

        private DailyModel()
        {
        }

        public void ShowDailyPanel(JSONNode json)
        {
            if (OpenPanel != null)
            {
                OpenPanel(json);
            }
        }

        public int MyCoinCount
        {
            get { return myCoinCount; }
            set
            {
                if (OnCoinAni != null)
                {
                    OnCoinAni(value - MyCoinCount);
                }

                myCoinCount = value;
                if (OnCoinChange != null)
                {
                    OnCoinChange(myCoinCount);
                }
            }
        }
    }
}
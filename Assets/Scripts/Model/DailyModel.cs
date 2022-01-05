namespace Model
{
    public class DailyModel
    {
        public OnValueChange OnCoinChange;

        public OnValueChange OnCoinAni;

        public int SolderBuyTimes { get; set; } = 0;

        private int myCoinCount = 0;

        /// 模型委托（当用户信息发生变化时执行）
        public delegate void OnValueChange(int val);

        //单例
        private static DailyModel singleton = null;

        public static DailyModel CreateInstance()
        {
            return singleton ?? (singleton = new DailyModel());
        }

        public int MyCoinCount
        {
            get
            {
                return myCoinCount;
            }
            set
            {
                OnCoinAni?.Invoke(value - MyCoinCount);
                myCoinCount = value;
                OnCoinChange?.Invoke(myCoinCount);
            }
        }
    }
}
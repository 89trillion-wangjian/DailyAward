using SimpleJSON;

namespace Model
{
    public class GameModel 
    {

        public JSONNode JsonNode { get; set; }

        public int SolderBuyTimes { set; get; } = 0;

        public int MyCoinCount { get; set; } = 0;

        private static GameModel singleton;

        public static GameModel CreateInstance()
        {
            return singleton ?? (singleton = new GameModel());
        }
    }
}
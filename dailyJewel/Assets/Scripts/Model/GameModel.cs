using SimpleJSON;

namespace Model
{
    public class GameModel 
    {

        public JSONNode JsonNode { get; set; }

        private static GameModel singleton;

        public static GameModel CreateInstance()
        {
            return singleton ?? (singleton = new GameModel());
        }
    }
}
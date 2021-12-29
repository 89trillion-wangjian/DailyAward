using SimpleJSON;

namespace Model
{
    public class GameModel : BaseModel
    {
        public override string Name { get; } = "GameModel";
        public JSONNode JsonNode;

        private static GameModel _singleton;


        public static GameModel CreateInstance()
        {
            if (_singleton == null)
            {
                _singleton = new GameModel();
            }

            return _singleton;
        }
    }
}
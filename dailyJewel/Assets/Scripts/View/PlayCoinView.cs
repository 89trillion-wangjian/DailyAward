using UnityEngine;

namespace View
{
    public class PlayCoinView : MonoBehaviour
    {
        // Start is called before the first frame update
        private GameObject myAssets;
        private readonly float speed = 100.0f;
        private float waitTime;

        void Start()
        {
            myAssets = GameObject.Find("Canvas/dailyJewel/myAssets/my_coin/coinImage");
            Debug.Log(myAssets);
            PlayCoinAni();
        }

        private void PlayCoinAni()
        {
            if (!this.gameObject)
            {
                return;
            }

            if (Vector3.Distance(transform.position, myAssets.transform.position) > .6f)
            {
                Vector3 directionOfTravel = myAssets.transform.position - transform.position;
                directionOfTravel.Normalize();

                this.transform.Translate(
                    (directionOfTravel.x * speed * Time.deltaTime),
                    (directionOfTravel.y * speed * Time.deltaTime),
                    (directionOfTravel.z * speed * Time.deltaTime),
                    Space.World);
            }
            else
            {
                GameObject assets;
                assets = GameObject.Find("Canvas");
                assets.SendMessage("ReduceCoin");
                Destroy(this.gameObject);
            }

            Invoke("PlayCoinAni", 0.1f);
        }
    }
}
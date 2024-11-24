using LTX.Singletons;
using UnityEngine;

namespace FishyBusiness
{
    public class PlayerFactory : MonoSingletonFactory<Player>
    {
        public override Player CreateSingleton()
        {
            var player = Resources.Load<GameObject>("Prefabs/Player");

            var instance = Object.Instantiate(player);
            instance.name = "Player";

            return instance.GetComponent<Player>();
        }
    }
}
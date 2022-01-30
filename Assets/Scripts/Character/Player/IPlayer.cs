using UniRx;
using UnityEngine;

namespace ReGaSLZR.Character.Player
{

    public interface IPlayer
    {

        public interface IGetter
        {
            IReadOnlyReactiveProperty<GameObject> GetPlayer();
            Vector3 GetDirection(Vector3 origin);
            IReadOnlyReactiveProperty<uint> GetHealth();
            IReadOnlyReactiveProperty<uint> GetMaxHealth();
        }

        public interface ISetter
        {
            void SetPlayer(GameObject player);
            void SetHealth(uint health);
            void SetMaxHealth(uint health);
        }

    }

}
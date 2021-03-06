using UniRx;
using UnityEngine;

namespace ReGaSLZR.Character.Player
{

    public interface IPlayer
    {

        public interface IGetter
        {
            IReadOnlyReactiveProperty<GameObject> GetPlayer();
            bool HasPlayer();
            Vector3 GetPosition();
            Vector3 GetDirection(Vector3 origin);
            IReadOnlyReactiveProperty<uint> GetHealth();
            IReadOnlyReactiveProperty<uint> GetMaxHealth();
            IReadOnlyReactiveProperty<int> GetScore();
        }

        public interface ISetter
        {
            void SetPlayer(GameObject player);
            void SetHealth(uint health);
            void SetMaxHealth(uint health);
            void IncrementScore();
        }

    }

}
using UniRx;
using UnityEngine;
using Zenject;

namespace ReGaSLZR.Character.Player
{

    public class PlayerModel : MonoInstaller<PlayerModel>, IPlayer.IGetter, IPlayer.ISetter
    {

        private IReactiveProperty<GameObject> rPlayer = new ReactiveProperty<GameObject>();

        private IReactiveProperty<uint> rHealth = new ReactiveProperty<uint>(1);
        private IReactiveProperty<uint> rMaxHealth = new ReactiveProperty<uint>(1);
        public override void InstallBindings()
        {
            Container.BindInstance<IPlayer.IGetter>(this);
            Container.BindInstance<IPlayer.ISetter>(this);
        }

        #region Interface Implementations

        public IReadOnlyReactiveProperty<GameObject> GetPlayer()
        {
            return rPlayer;
        }

        public bool HasPlayer() => rPlayer.Value != null;

        public Vector3 GetPosition() => rPlayer.Value.transform.position;

        public Vector3 GetDirection(Vector3 origin)
        {
            return (rPlayer.Value.transform.position - origin).normalized;
        }

        public IReadOnlyReactiveProperty<uint> GetHealth() => rHealth;

        public IReadOnlyReactiveProperty<uint> GetMaxHealth() => rMaxHealth;

        public void SetPlayer(GameObject player)
        {
            rPlayer.Value = player;
        }

        public void SetHealth(uint health)
        {
            rHealth.Value = health;
        }

        public void SetMaxHealth(uint health)
        {
            rMaxHealth.Value = health;
        }

        #endregion

    }

}
using NaughtyAttributes;
using ReGaSLZR.Base;
using ReGaSLZR.Config;
using UniRx;
using UnityEngine;
using Zenject;

namespace ReGaSLZR.Character.Enemy
{

    public class EnemyBrain : ReactiveMonoBehaviour
    {

        [SerializeField]
        [Required]
        private EnemyConfigSO config;
        public Config.Enemy Config => config.Config;


        public void OnDeath()
        {
            gameObject.SetActive(false); //TODO improve this
        }

        protected override void RegisterObservables()
        {
            //todo
        }

    }

}
using NaughtyAttributes;
using ReGaSLZR.Base;
using UniRx;
using UnityEngine;
using Zenject;

namespace ReGaSLZR.Character.Enemy
{

    public class EnemyBrain : ReactiveMonoBehaviour
    {

        [SerializeField]
        [Required]
        private EnemyHealth health; 

        //[Inject]
        //private IPlayer.IGetter player;

        protected override void RegisterObservables()
        {
            health.GetHealth()
                .Where(health => health == 0)
                .Subscribe(_ => gameObject.SetActive(false)) //TODO improve this
                .AddTo(disposablesBasic);
        }
    }

}
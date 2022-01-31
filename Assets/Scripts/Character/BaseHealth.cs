using ReGaSLZR.Base;
using UniRx;
using UnityEngine;

namespace ReGaSLZR.Character
{

    public abstract class BaseHealth : ReactiveMonoBehaviour
    {

        protected uint maxHealth = 3;
        protected IReactiveProperty<int> health = new ReactiveProperty<int>(3);

        public virtual void SetMaxHealth(uint maxHealth)
        {
            this.maxHealth = maxHealth;
            health.Value = (int)maxHealth;
        }

        public virtual void Damage(uint damage)
        {
            health.Value = Mathf.Clamp((health.Value - (int)damage), 0, (int)maxHealth);
        }

        public IReadOnlyReactiveProperty<int> GetHealth() => health;

    }

}
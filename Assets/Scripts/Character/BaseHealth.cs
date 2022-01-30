using ReGaSLZR.Base;
using UniRx;
using UnityEngine;

namespace ReGaSLZR.Character
{

    public abstract class BaseHealth : ReactiveMonoBehaviour
    {

        protected uint maxHealth = 3;
        protected IReactiveProperty<uint> health = new ReactiveProperty<uint>(3);

        public virtual void SetMaxHealth(uint maxHealth)
        {
            this.maxHealth = maxHealth;
            health.Value = maxHealth;
        }

        public virtual void Damage(uint damage)
        {
            health.Value = (uint)Mathf.Clamp((health.Value - damage), 0, maxHealth);
        }

        public IReadOnlyReactiveProperty<uint> GetHealth() => health;

    }

}
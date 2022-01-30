using NaughtyAttributes;
using ReGaSLZR.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReGaSLZR.Bullet
{

    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class BulletController : MonoBehaviour
    {

        #region Inspector Fields

        [SerializeField]
        [Tag]
        private List<string> targetTags = new List<string>();

        #endregion

        private Rigidbody rigidBody;
        private BulletPooler pooler;

        private uint damage;
        private float force;

        #region Unity Callbacks

        private void Awake()
        {
            rigidBody = GetComponent<Rigidbody>();
            GetComponent<Collider>().isTrigger = true;
        }

        private void FixedUpdate()
        {
            rigidBody.velocity = transform.forward * force;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (targetTags.Contains(other.tag))
            {
                var health = other.GetComponent<CharacterHealth>();
                if (health == null)
                {
                    return;
                }

                health.Damage(damage);
                StopAllCoroutines();
                pooler.ReturnPooledItem(this);
            }
        }

        #endregion

        #region Class Implementation

        private IEnumerator C_ApplyLifetime(float lifetime)
        {
            yield return new WaitForSeconds(lifetime);
            pooler.ReturnPooledItem(this);
        }

        #endregion

        #region Public API

        public void SetPooler(BulletPooler pooler)
        {
            this.pooler = pooler;
        }

        public void SetDamage(uint damage)
        {
            this.damage = damage;
        }

        public void ApplyLifetime(float lifetime)
        {
            StopAllCoroutines();
            StartCoroutine(C_ApplyLifetime(lifetime));
        }

        public void ApplyForce(float force)
        {
            this.force = force;
        }

        #endregion

    }

}
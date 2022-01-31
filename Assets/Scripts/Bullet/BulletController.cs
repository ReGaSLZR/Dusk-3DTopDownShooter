using NaughtyAttributes;
using ReGaSLZR.Character;
using ReGaSLZR.Constant;
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

        #region Private Fields

        private Rigidbody rigidBody;
        private BulletPooler pooler;

        private uint damage;
        private float travelSpeed;

        #endregion

        #region Unity Callbacks

        private void Awake()
        {
            rigidBody = GetComponent<Rigidbody>();
            GetComponent<Collider>().isTrigger = true;
        }

        private void FixedUpdate()
        {
            rigidBody.velocity = transform.forward * travelSpeed;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (Tag.WALL.Equals(other.tag))
            {
                DisableSelf();
                return;
            }

            if (targetTags.Contains(other.tag))
            {
                var health = other.GetComponent<BaseHealth>();
                if (health == null)
                {
                    return;
                }

                health.Damage(damage);
                DisableSelf();
            }
        }

        #endregion

        #region Class Implementation

        private void DisableSelf()
        {
            StopAllCoroutines();
            pooler.ReturnPooledItem(this);
        }

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

        public void SetSpeed(float speed)
        {
            travelSpeed = speed;
        }

        #endregion

    }

}
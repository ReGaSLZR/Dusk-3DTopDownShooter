using System.Collections;
using UnityEngine;

namespace ReGaSLZR.Bullet
{

    [RequireComponent(typeof(Rigidbody))]
    public class BulletController : MonoBehaviour
    {

        private Rigidbody rigidBody;
        private BulletPooler pooler;

        private float force;

        #region Unity Callbacks

        private void Awake()
        {
            rigidBody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            rigidBody.velocity = transform.forward * force;
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
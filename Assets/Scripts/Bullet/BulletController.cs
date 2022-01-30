using UnityEngine;

namespace ReGaSLZR.Bullet
{

    [RequireComponent(typeof(Rigidbody))]
    public class BulletController : MonoBehaviour
    {

        private Rigidbody rigidBody;

        private float force;

        private void Awake()
        {
            rigidBody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            rigidBody.velocity = transform.forward * force;
        }

        #region Public API

        public void ApplyLifetime(float lifetime)
        {
            Destroy(gameObject, lifetime);
        }

        public void ApplyForce(float force)
        {
            this.force = force;
        }

        #endregion

    }

}
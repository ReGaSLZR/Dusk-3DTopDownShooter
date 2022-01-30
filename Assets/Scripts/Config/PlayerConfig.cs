using UnityEngine;

namespace ReGaSLZR.Config
{

    [System.Serializable]
    public class PlayerConfig
    {

        #region Fields

        [SerializeField]
        [Range(0.1f, 20f)]
        private float speedMovement = 3f;
        public float SpeedMovement => speedMovement;

        [SerializeField]
        [Range(0.1f, 20f)]
        private float speedRotation = 3f;
        public float SpeedRotation => speedRotation;

        [SerializeField]
        [Range(1f, 5f)]
        private float mouseSensitivity = 3f;
        public float MouseSensitivity => mouseSensitivity;

        [SerializeField]
        [Range(0.0001f, 5f)]
        private float fireCooldown = 0.5f;
        public float FireCooldown => fireCooldown;

        [Space]

        [SerializeField]
        [Range(0.1f, 5f)]
        private float bulletLifetime = 3f;
        public float BulletLifetime => bulletLifetime;

        [SerializeField]
        [Range(0.1f, 30f)]
        private float bulletForce = 3f;
        public float BulletForce => bulletForce;

        #endregion

    }

}
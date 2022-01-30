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
        [Range(1, 50)]
        private uint bulletDamage = 3;
        public uint BulletDamage => bulletDamage;

        [SerializeField]
        [Range(0.1f, 5f)]
        private float bulletLifetime = 3f;
        public float BulletLifetime => bulletLifetime;

        [SerializeField]
        [Range(0.1f, 30f)]
        private float bulletTravelSpeed = 3f;
        public float BulletTravelSpeed => bulletTravelSpeed;

        [SerializeField]
        [Range(0, 50)]
        [Tooltip("Change only takes effect upon restart")]
        private uint bulletPoolCount = 20;
        public uint BulletPoolCount => bulletPoolCount;

        #endregion

    }

}
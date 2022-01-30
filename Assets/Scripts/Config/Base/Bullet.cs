using UnityEngine;

namespace ReGaSLZR.Config
{

    [System.Serializable]
    public class Bullet
    {

        [SerializeField]
        [Range(0.0001f, 3f)]
        private float fireCooldown = 0.5f;
        public float FireCooldown => fireCooldown;

        [SerializeField]
        [Range(1, 50)]
        private uint damage = 3;
        public uint Damage => damage;

        [SerializeField]
        [Range(0.1f, 5f)]
        private float lifetime = 3f;
        public float Lifetime => lifetime;

        [SerializeField]
        [Range(0.1f, 30f)]
        private float travelSpeed = 3f;
        public float Speed => travelSpeed;

        [SerializeField]
        [Range(0, 50)]
        [Tooltip("Change only takes effect upon restart")]
        private uint poolCount = 20;
        public uint PoolCount => poolCount;

    }

}
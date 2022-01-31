using NaughtyAttributes;
using UnityEngine;

namespace ReGaSLZR.Config
{

    [System.Serializable]
    public class Bullet
    {

        [SerializeField]
        [Range(0.0001f, 5f)]
        private float attackInterval = 0.5f;
        public float AttackInterval => attackInterval;

        [SerializeField]
        [Range(1, 50)]
        private uint damage = 3;
        public uint Damage => damage;

        [SerializeField]
        [Range(0.1f, 15f)]
        private float lifetime = 3f;
        public float Lifetime => lifetime;

        [SerializeField]
        [Range(0.1f, 50f)]
        private float travelSpeed = 3f;
        public float Speed => travelSpeed;

        [SerializeField]
        [Range(1, 50)]
        [InfoBox("Change to the field below only takes effect upon restart", EInfoBoxType.Normal)]
        private uint poolCount = 20;
        public uint PoolCount => poolCount;

    }

}
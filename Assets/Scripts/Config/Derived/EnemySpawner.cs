using UnityEngine;

namespace ReGaSLZR.Config
{

    [System.Serializable]
    public class EnemySpawner
    {

        [SerializeField]
        private uint poolCountPerType = 2;
        public uint PoolCountPerType => poolCountPerType;

        [SerializeField]
        [Range(10f, 200f)]
        private float waveIntervalInSeconds = 25f;
        public float WaveIntervalInSeconds => waveIntervalInSeconds;

    }

}
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
        [Range(15f, 150f)]
        private float waveIntervalInSeconds = 25f;
        public float WaveIntervalInSeconds => waveIntervalInSeconds;

    }

}
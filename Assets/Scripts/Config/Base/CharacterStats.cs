using UnityEngine;

namespace ReGaSLZR.Config
{

    [System.Serializable]
    public class CharacterStats
    {

        [SerializeField]
        [Range(1, 100)]
        [Tooltip("Change only takes effect upon restart")]
        private uint maxHealth = 3;
        public uint MaxHealth => maxHealth;

    }
}

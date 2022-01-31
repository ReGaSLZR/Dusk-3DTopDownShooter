using NaughtyAttributes;
using UnityEngine;

namespace ReGaSLZR.Config
{

    [System.Serializable]
    public class CharacterStats
    {

        [SerializeField]
        [Range(1, 100)]
        [InfoBox("Change to the field below only takes effect upon restart", EInfoBoxType.Normal)]
        private uint maxHealth = 3;
        public uint MaxHealth => maxHealth;

    }
}

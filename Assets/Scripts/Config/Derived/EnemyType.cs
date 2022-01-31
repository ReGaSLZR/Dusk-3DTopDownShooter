using NaughtyAttributes;
using ReGaSLZR.Character.Enemy;
using System.Collections.Generic;
using UnityEngine;

namespace ReGaSLZR.Config
{

    [System.Serializable]
    public class EnemyTypes
    {

        [SerializeField]
        private List<EnemyType> entries = new List<EnemyType>();
        public List<EnemyType> Entries => entries;

    }

    [System.Serializable]
    public class EnemyType
    {

        [SerializeField]
        [Required]
        private EnemyBrain prefabBrain;
        public EnemyBrain PrefabBrain => prefabBrain;

        [SerializeField]
        [Required]
        private EnemyConfigSO config;
        public EnemyConfigSO Config => config;

        public static bool IsValid(EnemyType type)
        {
            return (type != null) && (type.PrefabBrain != null) && (type.Config != null);
        }

    }

}
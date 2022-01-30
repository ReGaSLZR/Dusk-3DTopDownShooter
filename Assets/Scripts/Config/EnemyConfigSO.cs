using UnityEngine;

namespace ReGaSLZR.Config
{

    [CreateAssetMenu(fileName = "New Enemy Config", menuName = "ReGaSLZR/Config/New Enemy")]
    public class EnemyConfigSO : ScriptableObject
    {

        #region Fields

        [SerializeField]
        private Enemy config = new Enemy();
        public Enemy Config => config;

        #endregion

    }

}
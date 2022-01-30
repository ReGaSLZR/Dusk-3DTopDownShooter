using UnityEngine;

namespace ReGaSLZR.Config
{

    [System.Serializable]
    public class Enemy
    {

        #region Fields

        [SerializeField]
        private CharacterStats stats;
        public CharacterStats Stats => stats;

        [SerializeField]
        private Movement movement;
        public Movement Mvmt => movement;

        [SerializeField]
        private Bullet bullet;
        public Bullet Bullet => bullet;

        #endregion

    }

}
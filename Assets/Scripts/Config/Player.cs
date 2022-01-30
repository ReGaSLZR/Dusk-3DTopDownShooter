using UnityEngine;

namespace ReGaSLZR.Config
{

    [System.Serializable]
    public class Player
    {

        #region Fields

        [SerializeField]
        private CharacterStats stats;
        public CharacterStats Stats => stats;

        [SerializeField]
        private Movement movement;
        public Movement Mvmt => movement;

        [SerializeField]
        [Range(0.1f, 20f)]
        private float speedRotation = 3f;
        public float SpeedRotation => speedRotation;

        [SerializeField]
        [Range(1f, 5f)]
        private float mouseSensitivity = 3f;
        public float MouseSensitivity => mouseSensitivity;

        [SerializeField]
        private Bullet bullet;
        public Bullet Bullet => bullet;

        #endregion

    }

}
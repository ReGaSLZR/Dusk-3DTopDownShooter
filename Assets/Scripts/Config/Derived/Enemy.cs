using ReGaSLZR.Character.Enemy;
using UnityEngine;

namespace ReGaSLZR.Config
{

    [System.Serializable]
    public class Enemy
    {

        #region Fields

        [SerializeField]
        private CharacterStats stats = new CharacterStats();
        public CharacterStats Stats => stats;

        [SerializeField]
        private Movement movement = new Movement();
        public Movement Mvmt => movement;

        [SerializeField]
        private MoveType moveType = MoveType.Stationary;
        public MoveType MoveType => moveType;

        [SerializeField]
        [Range(1f, 50f)]
        private float attackDistance = 5f;
        public float AttackDistance => attackDistance;

        [SerializeField]
        private Bullet bullet = new Bullet();
        public Bullet Bullet => bullet;

        #endregion

    }

}
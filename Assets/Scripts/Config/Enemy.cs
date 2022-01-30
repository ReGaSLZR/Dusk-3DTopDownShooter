using ReGaSLZR.Character.Enemy;
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
        private MoveType moveType;
        public MoveType MoveType => moveType;

        [SerializeField]
        [Range(1f, 35f)]
        private float attackDistance = 5f;
        public float AttackDistance => attackDistance;

        [SerializeField]
        private Bullet bullet;
        public Bullet Bullet => bullet;

        #endregion

    }

}
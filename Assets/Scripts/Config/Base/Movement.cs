using UnityEngine;

namespace ReGaSLZR.Config
{

    [System.Serializable]
    public class Movement
    {

        [SerializeField]
        [Range(0.1f, 20f)]
        private float speedMovement = 3f;
        public float SpeedMovement => speedMovement;

        [SerializeField]
        [Range(0.1f, 20f)]
        private float speedRotation = 3f;
        public float SpeedRotation => speedRotation;

    }

}
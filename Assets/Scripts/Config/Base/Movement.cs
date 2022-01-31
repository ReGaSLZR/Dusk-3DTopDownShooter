using UnityEngine;

namespace ReGaSLZR.Config
{

    [System.Serializable]
    public class Movement
    {

        [SerializeField]
        [Range(0.1f, 50f)]
        private float speedMovement = 3f;
        public float SpeedMovement => speedMovement;

    }

}
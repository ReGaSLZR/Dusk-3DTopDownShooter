using ReGaSLZR.Config;
using UnityEngine;
using Zenject;

namespace ReGaSLZR.Character.Player
{

    public class PlayerBrain : MonoBehaviour
    {

        [Inject]
        private IPlayer.ISetter playerSetter;

        //[Inject]
        //private PlayerConfig config;

        private void Start()
        {
            playerSetter.SetPlayer(gameObject);
            

            //TODO more things here...
        }

    }

}
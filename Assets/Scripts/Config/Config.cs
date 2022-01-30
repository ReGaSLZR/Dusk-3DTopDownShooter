using UnityEngine;
using Zenject;

namespace ReGaSLZR.Config
{

    [CreateAssetMenu(fileName = "New Config", menuName = "ReGaSLZR/Config")]
    public class Config : ScriptableObjectInstaller<Config>
    {

        #region Fields

        [SerializeField]
        private PlayerConfig player;
        public PlayerConfig Player => player;

        #endregion

        public override void InstallBindings()
        {
            Container.BindInstances(player);
        }

    }

}
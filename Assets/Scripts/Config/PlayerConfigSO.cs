using UnityEngine;
using Zenject;

namespace ReGaSLZR.Config
{

    [CreateAssetMenu(fileName = "New Player Config", menuName = "ReGaSLZR/Config/New Player")]
    public class PlayerConfigSO : ScriptableObjectInstaller<PlayerConfigSO>
    {

        #region Fields

        [SerializeField]
        private Player player;
        
        #endregion

        public override void InstallBindings()
        {
            Container.BindInstances(player);
        }

    }

}
using UnityEngine;
using Zenject;

namespace ReGaSLZR.Config
{

    [CreateAssetMenu(fileName = "New Player Config", menuName = "ReGaSLZR/Config")]
    public class PlayerConfigSO : ScriptableObjectInstaller<PlayerConfigSO>
    {

        #region Fields

        [SerializeField]
        private PlayerConfig player;
        
        #endregion

        public override void InstallBindings()
        {
            Container.BindInstances(player);
        }

    }

}
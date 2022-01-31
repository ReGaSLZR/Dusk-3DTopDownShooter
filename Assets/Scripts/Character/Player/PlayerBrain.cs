using ReGaSLZR.Data;
using ReGaSLZR.Utils;
using Zenject;

namespace ReGaSLZR.Character.Player
{

    public class PlayerBrain : BaseBrain
    {

        #region Private Fields

        [Inject]
        private IPlayer.IGetter playerGetter;

        [Inject]
        private IPlayer.ISetter playerSetter;

        [Inject]
        private IData.IGetter dataGetter;

        [Inject]
        private IData.ISetter dataSetter;

        #endregion

        private void Start()
        {
            playerSetter.SetPlayer(gameObject);
        }

        #region Class Overrides

        public override void OnDeath()
        {
            if (dataGetter.GetHighScore().Value < playerGetter.GetScore().Value)
            {
                dataSetter.SetHighScore(playerGetter.GetScore().Value);
                dataSetter.Save();
            }

            gameObject.SetActive(false);
            SceneUtil.RestartCurrent();
        }

        #endregion

    }

}
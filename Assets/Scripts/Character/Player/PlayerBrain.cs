using ReGaSLZR.Data;
using ReGaSLZR.Utils;
using Zenject;

namespace ReGaSLZR.Character.Player
{

    public class PlayerBrain : BaseBrain
    {

        [Inject]
        private IPlayer.IGetter playerGetter;

        [Inject]
        private IPlayer.ISetter playerSetter;

        [Inject]
        private IData.IGetter dataGetter;

        [Inject]
        private IData.ISetter dataSetter;

        private void Start()
        {
            playerSetter.SetPlayer(gameObject);
        }

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

    }

}
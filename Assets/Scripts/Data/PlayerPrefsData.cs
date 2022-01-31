using UniRx;
using UnityEngine;
using Zenject;

namespace ReGaSLZR.Data
{

    public class PlayerPrefsData : MonoInstaller<PlayerPrefsData>, 
        IData.IGetter, IData.ISetter
    {

        private const string KEY_HIGH_SCORE = "KEY_HIGH_SCORE";

        private IReactiveProperty<int> rHighScore = new ReactiveProperty<int>(0);

        public override void InstallBindings()
        {
            Container.BindInstance<IData.IGetter>(this);   
            Container.BindInstance<IData.ISetter>(this);   
        }

        private void Awake()
        {
            rHighScore.Value = PlayerPrefs.GetInt(KEY_HIGH_SCORE, 0);
        }

        #region Interface Getter Implementations

        public IReadOnlyReactiveProperty<int> GetHighScore() => rHighScore;

        #endregion 

        #region Interface Setter Implementations

        public void SetHighScore(int highScore)
        {
            rHighScore.Value = highScore;
        }

        public void Save()
        {
            PlayerPrefs.SetInt(KEY_HIGH_SCORE, rHighScore.Value);
            PlayerPrefs.Save();
        }

        #endregion

    }

}
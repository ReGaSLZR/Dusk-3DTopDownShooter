using UniRx;

namespace ReGaSLZR.Data
{

    public interface IData
    {

        public interface IGetter
        {

            IReadOnlyReactiveProperty<int> GetHighScore();

        }

        public interface ISetter
        {

            void SetHighScore(int highScore);
            void Save();

        }

    }

}
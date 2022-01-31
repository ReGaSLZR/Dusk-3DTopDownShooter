using ReGaSLZR.Pooling;

namespace ReGaSLZR.Character.Enemy
{

    public class EnemyPooler : Pooler<EnemyBrain>
    {

        #region Public API

        public void SetPrefab(EnemyBrain prefab)
        {
            prefabItem = prefab;
        }

        #endregion

    }

}
using ReGaSLZR.Pooling;

namespace ReGaSLZR.Character.Enemy
{

    public class EnemyPooler : Pooler<EnemyBrain>
    {

        public void SetPrefab(EnemyBrain prefab)
        {
            prefabItem = prefab;
        }

    }

}
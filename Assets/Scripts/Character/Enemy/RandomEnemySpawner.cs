using ReGaSLZR.Character.Player;
using ReGaSLZR.Config;
using ReGaSLZR.Prefab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ReGaSLZR.Character.Enemy
{

    public class RandomEnemySpawner : MonoBehaviour
    {

        #region Private Fields

        [Inject]
        private IPrefabInjector prefabInjector;

        [Inject]
        private IPlayer.IGetter player;

        [Inject]
        private EnemyTypes enemyTypes;

        [Inject]
        private EnemySpawner spawnerConfig;

        private List<EnemyPooler> poolers = new List<EnemyPooler>();

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            SetUpPoolers();
            StartCoroutine(C_Spawn());
        }

        #endregion

        #region Class Implementation

        private void SetUpPoolers()
        {
            for (int x = 0; x < enemyTypes.Entries.Count; x++)
            {
                var pooler = gameObject.AddComponent<EnemyPooler>();

                var prefab = enemyTypes.Entries[x].PrefabBrain;
                prefab.SetConfig(enemyTypes.Entries[x].Config);
                pooler.SetPrefab(prefab);
                pooler.SetItemsLiveOnUponDisable(true);
                pooler.SetUp(spawnerConfig.PoolCountPerType);
                poolers.Add(pooler);
            }
        }

        private IEnumerator C_Spawn()
        {
            while (player.GetHealth().Value > 0)
            {
                Spawn();
                yield return new WaitForSeconds(spawnerConfig.WaveIntervalInSeconds);
            }
        }

        private void Spawn()
        {
            var index = Random.Range(0, enemyTypes.Entries.Count);
            var enemy = poolers[index].GetPooledItem();

            enemy.gameObject.SetActive(false);
            enemy.SetPooler(poolers[index]);
            prefabInjector.InjectPrefab(enemy.gameObject);
            enemy.SetConfig(enemyTypes.Entries[index].Config);
            enemy.transform.position = gameObject.transform.position;
            enemy.gameObject.SetActive(true);
        }

        #endregion

    }

}
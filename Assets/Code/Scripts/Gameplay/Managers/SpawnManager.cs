using CartoonZombieVR.ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;

namespace CartoonZombieVR.Gameplay
{
    public class SpawnManager : MonoBehaviour
    {
        public GameObject enemyPrefab;
        public List<EnemyTypeConfig> basicEnemyTypes;
        public List<EnemyTypeConfig> bossEnemyTypes;
        public Transform enemiesParentContainer;
        public int maxBasicAliveEnemies = 1;
        public int maxBossAliveEnemies = 0;

        private EnemySpawnPoint[] enemiesSpawnPoints;
        private TeamManager teamManager;

        private void Start()
        {
            teamManager = FindObjectOfType<TeamManager>();
            enemiesSpawnPoints = FindObjectsOfType<EnemySpawnPoint>();
        }

        private void Update()
        {
            SpawnEnemies();
        }

        private void SpawnEnemies()
        {
            List<TeamMember> allEnemies = teamManager.GetTeam(TeamAffiliation.Enemies).members;
            int basicEnemiesAliveCount = 0;
            int bossEnemiesAliveCount = 0;
            foreach (TeamMember enemy in allEnemies)
            {
                EnemyDifficulty enemyDifficulty = enemy.GetComponent<Enemy>().typeConfig.enemyDifficulty;
                if (enemyDifficulty == EnemyDifficulty.Basic)
                {
                    basicEnemiesAliveCount++;
                }
                else if (enemyDifficulty == EnemyDifficulty.Boss)
                {
                    bossEnemiesAliveCount++;
                }
            }

            while (basicEnemiesAliveCount < maxBasicAliveEnemies)
            {
                SpawnNewEnemy(EnemyDifficulty.Basic);
                basicEnemiesAliveCount++;
            }

            while (bossEnemiesAliveCount < maxBossAliveEnemies)
            {
                Debug.Log("SpawnBoss");
                SpawnNewEnemy(EnemyDifficulty.Boss);
                bossEnemiesAliveCount++;
            }
        }

        private void SpawnNewEnemy(EnemyDifficulty enemyDifficulty)
        {
            EnemySpawnPoint enemySpawnPoint = GetRandomSpawnPoint();

            Enemy enemy = Instantiate(
                enemyPrefab,
                enemySpawnPoint.transform.position,
                enemySpawnPoint.transform.rotation,
                enemiesParentContainer
            ).GetComponent<Enemy>();

            enemy.typeConfig = GetRandomEnemyTypeConfig(enemyDifficulty);
        }

        private EnemySpawnPoint GetRandomSpawnPoint()
        {
            int randomIndex = Random.Range(0, enemiesSpawnPoints.Length);
            return enemiesSpawnPoints[randomIndex];
        }

        private EnemyTypeConfig GetRandomEnemyTypeConfig(EnemyDifficulty enemyDifficulty)
        {
            if (enemyDifficulty == EnemyDifficulty.Basic)
            {
                if (basicEnemyTypes.Count == 0)
                {
                    return null;
                }

                int randomIndex = Random.Range(0, basicEnemyTypes.Count);
                return basicEnemyTypes[randomIndex];
            }
            else if (enemyDifficulty == EnemyDifficulty.Boss)
            {
                if (bossEnemyTypes.Count == 0)
                {
                    return null;
                }

                int randomIndex = Random.Range(0, bossEnemyTypes.Count);
                return bossEnemyTypes[randomIndex];
            }

            return null;
        }
    }
}


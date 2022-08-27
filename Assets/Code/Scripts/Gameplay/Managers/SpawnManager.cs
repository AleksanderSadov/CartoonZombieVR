using UnityEngine;

namespace CartoonZombieVR.Gameplay
{
    public class SpawnManager : MonoBehaviour
    {
        public GameObject enemyPrefab;
        public Transform enemiesParentContainer;
        public int maxAliveEnemies = 1;

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
            int currentAliveEnemiesCount = teamManager.GetTeam(TeamAffiliation.Enemies).members.Count;
            while (currentAliveEnemiesCount < maxAliveEnemies)
            {
                SpawnNewEnemy();
                currentAliveEnemiesCount++;
            }
        }

        private void SpawnNewEnemy()
        {
            EnemySpawnPoint enemySpawnPoint = GetRandomSpawnPoint();

            Instantiate(
                enemyPrefab,
                enemySpawnPoint.transform.position,
                enemySpawnPoint.transform.rotation,
                enemiesParentContainer
            );
        }

        private EnemySpawnPoint GetRandomSpawnPoint()
        {
            int randomIndex = Random.Range(0, enemiesSpawnPoints.Length);
            return enemiesSpawnPoints[randomIndex];
        }
    }
}


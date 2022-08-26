using System.Collections;
using UnityEngine;

namespace CartoonZombieVR.Gameplay
{
    public class SpawnManager : MonoBehaviour
    {
        public GameObject enemyPrefab;
        public Transform spawnPoint;

        private void Start()
        {
            StartCoroutine(SpawnNewEnemy());
        }

        private IEnumerator SpawnNewEnemy()
        {
            while (true)
            {
                yield return new WaitForSeconds(5);
                Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation, null);
            }
        }
    }
}


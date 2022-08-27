using CartoonZombieVR.General;
using CartoonZombieVR.ScriptableObjects;
using UnityEngine;

namespace CartoonZombieVR.Gameplay
{
    public class GameManager : MonoBehaviour
    {
        public GameConfig gameConfig;
        public Timer gameTimer;
        public SpawnManager spawnManager;

        private void Start()
        {
            if (gameTimer != null || gameConfig != null)
            {
                gameTimer.SetTimerDuration(gameConfig.gameTimerDurationInSeconds);
                gameTimer.StartTimer();
            }
        }

        private void Update()
        {
            HandleEnemiesWaves();
        }

        private void HandleEnemiesWaves()
        {
            float timeExpired = gameTimer.timeExpired;
            EnemiesWaveHandler currentActiveWaveHandler = null;
            foreach (EnemiesWaveHandler waveHandler in gameConfig.enemiesWavesHandler)
            {
                if (waveHandler.timeExpired <= timeExpired)
                {
                    currentActiveWaveHandler = waveHandler;
                }
                else
                {
                    break;
                }
            }

            if (currentActiveWaveHandler != null)
            {
                spawnManager.maxBasicAliveEnemies = currentActiveWaveHandler.basicEnemiesMaxCount;
                spawnManager.maxBossAliveEnemies = currentActiveWaveHandler.bossEnemiesMaxCount;
            }
        }
    }
}

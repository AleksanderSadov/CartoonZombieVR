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
        public GameObject TutorialRing;
        public GameObject TutorialUI;
        public GameObject TimerUI;

        private void Start()
        {
            if (gameTimer != null || gameConfig != null)
            {
                gameTimer.SetTimerDuration(gameConfig.gameTimerDurationInSeconds);

                if (gameConfig.skipTutorial)
                {
                    StartGame();
                }
            }
        }

        private void Update()
        {
            if (!gameTimer.isTimerFinished)
            {
                HandleEnemiesWaves();
            }
            else
            {
                spawnManager.enabled = false;
            }
        }

        public void StartGame()
        {
            TutorialRing.SetActive(false);
            TutorialUI.SetActive(false);
            TimerUI.SetActive(true);
            gameTimer.StartTimer();
        }

        private void HandleEnemiesWaves()
        {
            if (!gameTimer.isTimerRunning)
            {
                return;
            }

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

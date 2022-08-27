using System;
using System.Collections.Generic;
using UnityEngine;

namespace CartoonZombieVR.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "ScriptableObjects/GameConfig", order = 110)]
    public class GameConfig : ScriptableObject
    {
        public bool skipTutorial = false;
        public float gameTimerDurationInSeconds = 300;
        public List<EnemiesWaveHandler> enemiesWavesHandler = new List<EnemiesWaveHandler>();

        private void OnValidate()
        {
            for (int i = 0; i < enemiesWavesHandler.Count; i++)
            {
                float previousWaveTime = i > 0 ? enemiesWavesHandler[i - 1].timeExpired : 0;

                enemiesWavesHandler[i].timeExpired = Mathf.Clamp(
                    enemiesWavesHandler[i].timeExpired,
                    previousWaveTime,
                    gameTimerDurationInSeconds
                );
            }
        }
    }

    [Serializable]
    public class EnemiesWaveHandler
    {
        public float timeExpired;
        public int basicEnemiesMaxCount;
        public int bossEnemiesMaxCount;
    } 
}


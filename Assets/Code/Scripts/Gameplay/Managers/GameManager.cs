using CartoonZombieVR.General;
using CartoonZombieVR.ScriptableObjects;
using UnityEngine;

namespace CartoonZombieVR.Gameplay
{
    public class GameManager : MonoBehaviour
    {
        public GameConfig gameConfig;
        public Timer gameTimer;

        private void Start()
        {
            if (gameTimer != null || gameConfig != null)
            {
                gameTimer.SetTimerDuration(gameConfig.gameTimerDurationInSeconds);
            }
        }
    }
}

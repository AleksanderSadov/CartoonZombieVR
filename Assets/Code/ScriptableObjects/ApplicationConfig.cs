using UnityEngine;

namespace CartoonZombieVR.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ApplicationConfig", menuName = "ScriptableObjects/ApplicationConfig", order = 108)]
    public class ApplicationConfig : ScriptableObject
    {
        [Header("Gameplay")]
        public GameConfig gameConfig;
        public PlayerConfig playerConfig;

        [Header("Testing")]
        [Header("FPS Counter")]
        public bool displayFPSCounter;
        public float fpsGoodThreshold = 72;
        public float fpsBadThreshold = 50;
        public float fpsUpdateInteval = 0.5f;
    } 
}


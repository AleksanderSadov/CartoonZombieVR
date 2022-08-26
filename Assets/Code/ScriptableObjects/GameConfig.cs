using UnityEngine;

namespace CartoonZombieVR.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "ScriptableObjects/GameConfig", order = 110)]
    public class GameConfig : ScriptableObject
    {
        public float gameTimerDurationInSeconds = 300;
    }
}


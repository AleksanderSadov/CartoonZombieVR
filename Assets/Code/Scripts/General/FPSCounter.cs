using UnityEngine;

namespace CartoonZombieVR.General
{
    public class FPSCounter : MonoBehaviour
    {
        public int framesPerSecond { get; private set; } = 0;
        public float milliseconds { get; private set; } = 0.0f;

        private float deltaTime = 0.0f;

        private void Update()
        {
            CalculateCurrentFPS();
        }

        private void CalculateCurrentFPS()
        {
            deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
            milliseconds = (deltaTime * 1000.0f);
            framesPerSecond = (int)(1.0f / deltaTime);
        }
    }
}

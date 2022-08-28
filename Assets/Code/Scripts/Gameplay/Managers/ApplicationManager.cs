using CartoonZombieVR.ScriptableObjects;
using UnityEngine;

namespace CartoonZombieVR.Gameplay
{
    public class ApplicationManager : MonoBehaviour
    {
        public ApplicationConfig applicationConfig;
        public GameObject fpsCounter;

        private void Update()
        {
            DisplayFPSCounter();
        }

        private void DisplayFPSCounter()
        {
            if (fpsCounter == null)
            {
                return;
            }

            if (applicationConfig.displayFPSCounter)
            {
                fpsCounter.SetActive(true);
            }
            else
            {
                fpsCounter.SetActive(false);
            }
        }
    }
}

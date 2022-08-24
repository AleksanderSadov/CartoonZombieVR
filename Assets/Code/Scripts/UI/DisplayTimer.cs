using CartoonZombieVR.General;
using TMPro;
using UnityEngine;

namespace CartoonZombieVR.UI
{
    public class DisplayTimer : MonoBehaviour
    {
        public Timer timer;
        public TextMeshProUGUI timerText;

        private void LateUpdate()
        {
            float remainingTime = timer.GetRemainigTime();
            DisplayTime(remainingTime);
        }

        private void DisplayTime(float timeToDisplay)
        {
            timeToDisplay += 1;
            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}


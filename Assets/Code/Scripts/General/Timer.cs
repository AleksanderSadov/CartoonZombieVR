using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

namespace CartoonZombieVR.General
{
    public class Timer : MonoBehaviour
    {
        public bool setDurationInScript = false;
        [HideIf("setDurationInScript")]
        public float timerDuration = 10;
        [HideIf("setDurationInScript")]
        public bool startTimerOnAwake = false;

        public UnityEvent timerStarted;
        public UnityEvent timerFinished;

        private float timeRemaining;
        private bool isTimerRunning = false;
        private bool isTimerStartedFired = false;

        private void Awake()
        {
            timeRemaining = timerDuration;

            if (startTimerOnAwake)
            {
                StartTimer();
            }
        }

        private void Update()
        {
            if (!isTimerRunning)
            {
                return;
            }

            if (!isTimerStartedFired)
            {
                timerStarted?.Invoke();
                isTimerStartedFired = true;
            }

            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                isTimerRunning = false;
                timerFinished?.Invoke();
            }
        }

        public float GetRemainigTime()
        {
            return timeRemaining;
        }

        public void StartTimer()
        {
            isTimerRunning = true;
        }

        public void PauseTimer()
        {
            isTimerRunning = false;
        }

        public void StopTimer()
        {
            isTimerRunning = false;
            timeRemaining = timerDuration;
        }

        public void SetTimerDuration(float duration)
        {
            timerDuration = duration;
            timeRemaining = duration;
        }
    }
}

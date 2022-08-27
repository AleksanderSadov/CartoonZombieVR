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
        public bool isTimerStarted { get; private set; } = false;
        public bool isTimerRunning { get; private set; } = false;
        public bool isTimerFinished { get; private set; } = false;
        public float timeRemaining { get; private set; }
        public float timeExpired
        {
            get 
            { 
                return timerDuration - timeRemaining; 
            }
        }

        public UnityEvent timerStarted;
        public UnityEvent timerFinished;

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
                isTimerFinished = true;
                timerFinished?.Invoke();
            }
        }

        public void StartTimer()
        {
            isTimerStarted = true;
            isTimerRunning = true;
            isTimerFinished = false;
        }

        public void PauseTimer()
        {
            isTimerRunning = false;
        }

        public void StopTimer()
        {
            isTimerStarted = false;
            isTimerRunning = false;
            isTimerFinished = false;
            timeRemaining = timerDuration;
        }

        public void SetTimerDuration(float duration)
        {
            timerDuration = duration;
            timeRemaining = duration;
        }
    }
}

using CartoonZombieVR.Gameplay;
using CartoonZombieVR.General;
using System.Collections;
using TMPro;
using UnityEngine;

namespace CartoonZombieVR.UI
{
    public class DisplayFPS : MonoBehaviour
    {
        private ApplicationManager applicationManager;
        private FPSCounter fpsCounter;
        private TextMeshProUGUI textOutput = null;
        private Coroutine showFpsCoroutine;

        private void Awake()
        {
            applicationManager = FindObjectOfType<ApplicationManager>();
            fpsCounter = GetComponent<FPSCounter>();
            textOutput = GetComponentInChildren<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            showFpsCoroutine = StartCoroutine(ShowFPS());
        }

        private void OnDisable()
        {
            StopCoroutine(showFpsCoroutine);
        }

        private IEnumerator ShowFPS()
        {
            while (true)
            {
                if (fpsCounter.framesPerSecond >= applicationManager.applicationConfig.fpsGoodThreshold)
                {
                    textOutput.color = Color.green;
                }
                else if (fpsCounter.framesPerSecond >= applicationManager.applicationConfig.fpsBadThreshold)
                {
                    textOutput.color = Color.yellow;
                }
                else
                {
                    textOutput.color = Color.red;
                }

                textOutput.text = "FPS:" + fpsCounter.framesPerSecond + "\n" + "MS:" + fpsCounter.milliseconds.ToString(".0");
                yield return new WaitForSeconds(applicationManager.applicationConfig.fpsUpdateInteval);
            }
        }
    }
}

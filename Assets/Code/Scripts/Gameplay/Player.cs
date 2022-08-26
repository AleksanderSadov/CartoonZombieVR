using CartoonZombieVR.General;
using CartoonZombieVR.ScriptableObjects;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace CartoonZombieVR.Gameplay
{
    public class Player : MonoBehaviour
    {
        public PlayerConfig playerConfig;
        public Volume playerGetHitVignetteVolume;

        private Health health;
        private Vignette getHitvignette;
        private ColorAdjustments deathColorAdjustments;
        private Coroutine enableHealCoroutine;
        private bool canHeal = true;

        private void Start()
        {
            VolumeProfile profile = playerGetHitVignetteVolume.sharedProfile;
            profile.TryGet(out getHitvignette);
            profile.TryGet(out deathColorAdjustments);

            health = GetComponent<Health>();
            health.SetInitialHealth(playerConfig.health);
            health.OnTakeDamage += OnTakeDamage;
            health.OnDeath += OnDeath;
        }

        private void Update()
        {
            DecreaseGetHitVignette();
            ContinuousHeal();
        }

        private void OnDestroy()
        {
            getHitvignette.intensity.value = 0;
            deathColorAdjustments.postExposure.value = 0;
        }

        private void DecreaseGetHitVignette()
        {
            if (getHitvignette.intensity.value > 0)
            {
                getHitvignette.intensity.value = Mathf.Clamp(
                    getHitvignette.intensity.value - Time.deltaTime / playerConfig.getHitVignetteDuration,
                    0,
                    1
                );
            }
        }

        private void ContinuousHeal()
        {
            if (canHeal && health.currentHealth < health.startingHealth)
            {
                health.Heal(playerConfig.continuousHealSpeed * Time.deltaTime);
            }
        }

        private void OnTakeDamage()
        {
            getHitvignette.intensity.value = 1;

            if (enableHealCoroutine != null)
            {
                StopCoroutine(enableHealCoroutine);
            }

            canHeal = false;
            enableHealCoroutine = StartCoroutine(EnableHeal(playerConfig.stopHealAfterHitDelay));
        }

        private void OnDeath()
        {
            StartCoroutine(HandleDeath());
        }

        private IEnumerator EnableHeal(float delay)
        {
            yield return new WaitForSeconds(delay);
            canHeal = true;
        }

        private IEnumerator HandleDeath()
        {
            yield return StartCoroutine(DarkenScreen(playerConfig.playerDeathExposureDarkValue, playerConfig.playerDeathDarkenScreenSpeed));
            SceneHelper.ReloadCurrentScene();
        }

        private IEnumerator DarkenScreen(float exposureDarkLimit, float exposureSpeed)
        {
            while (deathColorAdjustments.postExposure.value > exposureDarkLimit)
            {
                deathColorAdjustments.postExposure.value -= exposureSpeed * Time.deltaTime;
                yield return null;
            }
        }
    }
}


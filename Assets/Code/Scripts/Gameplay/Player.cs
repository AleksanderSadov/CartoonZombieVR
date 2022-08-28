using CartoonZombieVR.General;
using CartoonZombieVR.ScriptableObjects;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.XR.Interaction.Toolkit;

namespace CartoonZombieVR.Gameplay
{
    public class Player : MonoBehaviour
    {
        public Volume playerGetHitVignetteVolume;

        [Header("LeftHand")]
        public XRRayInteractor leftHandRayInteractor;
        public XRRayInteractor leftHandTeleportInteractor;
        [Header("RightHand")]
        public XRRayInteractor rightHandRayInteractor;
        public XRRayInteractor rightHandTeleportInteractor;

        private PlayerConfig playerConfig;
        private bool isConfigDirty = false;
        private ActionBasedSnapTurnProvider snapTurnProvider;
        private Health health;
        private Vignette getHitvignette;
        private ColorAdjustments deathColorAdjustments;
        private Coroutine enableHealCoroutine;
        private bool canHeal = true;

        private void Awake()
        {
            playerConfig = FindObjectOfType<ApplicationManager>().applicationConfig.playerConfig;
            health = GetComponent<Health>();
            snapTurnProvider = GetComponent<ActionBasedSnapTurnProvider>();
            VolumeProfile profile = playerGetHitVignetteVolume.sharedProfile;
            profile.TryGet(out getHitvignette);
            profile.TryGet(out deathColorAdjustments);
        }

        private void OnEnable()
        {
            playerConfig.OnConfigValuesChanged += MarkConfigDirty;
            UpdatePlayerFromConfig();
            health.OnTakeDamage += OnTakeDamage;
            health.OnDeath += OnDeath;
        }

        private void Update()
        {
            if (isConfigDirty)
            {
                isConfigDirty = false;
                UpdatePlayerFromConfig();
            }

            DecreaseGetHitVignette();
            ContinuousHeal();
        }

        private void OnDisable()
        {
            playerConfig.OnConfigValuesChanged -= MarkConfigDirty;
            health.OnTakeDamage -= OnTakeDamage;
            health.OnDeath -= OnDeath;
        }

        private void OnDestroy()
        {
            getHitvignette.intensity.value = 0;
            deathColorAdjustments.postExposure.value = 0;
        }

        private void MarkConfigDirty()
        {
            isConfigDirty = true;
        }

        private void UpdatePlayerFromConfig()
        {
            TogglePlayerXRInteractionType();
            health.SetInitialHealth(playerConfig.health);
            health.isInvincible = playerConfig.isInvincible;
        }

        private void TogglePlayerXRInteractionType()
        {
            if (playerConfig.playerXRInteractionType == PlayerXRInteractionType.FreeRoam)
            {
                leftHandRayInteractor.enabled = false;
                leftHandTeleportInteractor.enabled = false;
                rightHandRayInteractor.enabled = false;
                rightHandTeleportInteractor.enabled = false;
                snapTurnProvider.enabled = false;
            }
            else if (playerConfig.playerXRInteractionType == PlayerXRInteractionType.Teleport)
            {
                leftHandRayInteractor.enabled = true;
                leftHandTeleportInteractor.enabled = true;
                rightHandRayInteractor.enabled = true;
                rightHandTeleportInteractor.enabled = true;
                snapTurnProvider.enabled = true;
            }
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


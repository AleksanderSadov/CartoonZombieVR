using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

namespace CartoonZombieVR.ScriptableObjects
{
    public enum EnemyDifficulty
    {
        Basic,
        Boss
    }

    [CreateAssetMenu(fileName = "EnemyTypeConfig", menuName = "ScriptableObjects/EnemyTypeConfig", order = 220)]
    public class EnemyTypeConfig : OnChangeConfig
    {
        public EnemyGeneralConfig generalConfig;

        [Header("Difficulty")]
        public EnemyDifficulty enemyDifficulty = EnemyDifficulty.Basic;

        [Header("Movement")]
        public bool overrideEnemyNavMeshValues = false;
        [ShowIf("overrideEnemyNavMeshValues")]
        public float movementSpeed = 2;
        [ShowIf("overrideEnemyNavMeshValues")]
        public float movementAngularSpeed = 120;
        [ShowIf("overrideEnemyNavMeshValues")]
        public float movementAcceleration = 1;
        [ShowIf("overrideEnemyNavMeshValues")]
        public float movementStoppingDistance = 4;
        [ShowIf("overrideEnemyNavMeshValues")]
        public bool movementAutoBraking = true;

        [Header("Attack")]
        public string attackTargetTag = "Player";
        public float attackDamage = 25.0f;
        public float attackRange = 20.0f;
        public float attackAngle = 20.0f;
        public float attackSpeed = 1.0f;

        [Header("Health")]
        public float health = 100.0f;

        [Header("Size")]
        public Vector3 scale = new Vector3(1, 1, 1);

        [Header("BlendShapes")]
        [Range(0, 100)]
        public float blendShapeStrong = 0;
        [Range(0, 100)]
        public float blendShapeFat = 0;
        [Range(0, 100)]
        public float blendShapeLeftEyeSmall = 0;
        [Range(0, 100)]
        public float blendShapeRightEyeSmall = 0;
        [Range(0, 100)]
        public float blendShapeLeftEyeEmpty = 0;
        [Range(0, 100)]
        public float blendShapeRightEyeEmpty = 0;
        [Range(0, 100)]
        public float blendShapeChamfedHead = 0;
        [Range(0, 100)]
        public float blendShapeChamfedJaw = 0;
        [Range(0, 100)]
        public float blendShapeLeftSidedHead = 0;
        [Range(0, 100)]
        public float blendShapeRightSidedHead = 0;
        [Range(0, 100)]
        public float blendShapeLemonHead = 0;
        [Range(0, 100)]
        public float blendShapeNormalHead = 0;

        [Header("Audio")]
        public AudioClip audioRiseClip;
        public float audioRisePitchOriginal = 1;
        public float audioRisePitchRange = 0;
        public AudioMixerGroup audioRiseMixerGroup;
    }
}


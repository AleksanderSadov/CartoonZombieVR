using CartoonZombieVR.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace CartoonZombieVR.Gameplay
{
    public enum EnemyBlendShapes
    {
        Strong,
        Fat,
        LeftEyeSmall,
        RightEyeSmall,
        LeftEyeEmpty,
        RightEyeEmpty,
        ChamfedHead,
        ChamfedJaw,
        LeftSidedHead,
        RightSidedHead,
        LemonHead,
        NormalHead,
    }

    [ExecuteInEditMode]
    public class Enemy : MonoBehaviour
    {
        public EnemyTypeConfig typeConfig;
        public SkinnedMeshRenderer skinnedMeshRenderer;
        public UnityAction OnEnemyTypeChanged;

        private EnemyTypeConfig previousTypeConfig = null;
        private bool isConfigDirty = false;

        private void OnEnable()
        {
            typeConfig.OnConfigValuesChanged += MarkConfigDirty;
            previousTypeConfig = typeConfig;
            UpdateEnemyFromConfig();
        }

        private void OnDisable()
        {
            typeConfig.OnConfigValuesChanged -= MarkConfigDirty;
        }

        private void Update()
        {
            if (isConfigDirty || typeConfig != previousTypeConfig)
            {
                previousTypeConfig.OnConfigValuesChanged -= MarkConfigDirty;
                typeConfig.OnConfigValuesChanged += MarkConfigDirty;
                previousTypeConfig = typeConfig;
                isConfigDirty = false;

                UpdateEnemyFromConfig();
            }
        }

        private void MarkConfigDirty()
        {
            isConfigDirty = true;
        }

        private void UpdateEnemyFromConfig()
        {
            UpdateModelSize();
            UpdateBlendShapes();
            OnEnemyTypeChanged?.Invoke();
        }

        private void UpdateModelSize()
        {
            transform.localScale = typeConfig.scale;
        }

        private void UpdateBlendShapes()
        {
            if (skinnedMeshRenderer == null)
            {
                return;
            }

            skinnedMeshRenderer.SetBlendShapeWeight((int)EnemyBlendShapes.Strong, typeConfig.blendShapeStrong);
            skinnedMeshRenderer.SetBlendShapeWeight((int)EnemyBlendShapes.Fat, typeConfig.blendShapeFat);
            skinnedMeshRenderer.SetBlendShapeWeight((int)EnemyBlendShapes.LeftEyeSmall, typeConfig.blendShapeLeftEyeSmall);
            skinnedMeshRenderer.SetBlendShapeWeight((int)EnemyBlendShapes.RightEyeSmall, typeConfig.blendShapeRightEyeSmall);
            skinnedMeshRenderer.SetBlendShapeWeight((int)EnemyBlendShapes.LeftEyeEmpty, typeConfig.blendShapeLeftEyeEmpty);
            skinnedMeshRenderer.SetBlendShapeWeight((int)EnemyBlendShapes.RightEyeEmpty, typeConfig.blendShapeRightEyeEmpty);
            skinnedMeshRenderer.SetBlendShapeWeight((int)EnemyBlendShapes.ChamfedHead, typeConfig.blendShapeChamfedHead);
            skinnedMeshRenderer.SetBlendShapeWeight((int)EnemyBlendShapes.ChamfedJaw, typeConfig.blendShapeChamfedJaw);
            skinnedMeshRenderer.SetBlendShapeWeight((int)EnemyBlendShapes.LeftSidedHead, typeConfig.blendShapeLeftSidedHead);
            skinnedMeshRenderer.SetBlendShapeWeight((int)EnemyBlendShapes.RightSidedHead, typeConfig.blendShapeRightSidedHead);
            skinnedMeshRenderer.SetBlendShapeWeight((int)EnemyBlendShapes.LemonHead, typeConfig.blendShapeLemonHead);
            skinnedMeshRenderer.SetBlendShapeWeight((int)EnemyBlendShapes.NormalHead, typeConfig.blendShapeNormalHead);
        }
    }
}

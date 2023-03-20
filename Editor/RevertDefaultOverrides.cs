using UnityEditor;
using UnityEngine;

namespace Roxtone.RevertDefaultOverrides
{
    [InitializeOnLoad]
    internal static class RevertDefaultOverrides
    {
        static RevertDefaultOverrides()
        {
            ObjectChangeEvents.changesPublished -= OnChangesPublished;
            ObjectChangeEvents.changesPublished += OnChangesPublished;
        }

        private static void OnChangesPublished(ref ObjectChangeEventStream stream)
        {
            if (!Application.isPlaying && !RevertDefaultOverridesInput.DontRevertModifier && stream.GetEventType(0) == ObjectChangeKind.CreateGameObjectHierarchy)
            {
                stream.GetCreateGameObjectHierarchyEvent(0, out CreateGameObjectHierarchyEventArgs data);
                GameObject gameObject = (GameObject)EditorUtility.InstanceIDToObject(data.instanceId);
                if (PrefabUtility.GetPrefabInstanceHandle(gameObject) != null)
                {
                    SerializedObject gameObjectSO = new(gameObject);
                    RevertGameObject(gameObjectSO);
                    SerializedObject transformSO = new(gameObject.transform);
                    RevertTransform(transformSO);
                    if (gameObject.transform is RectTransform)
                    {
                        RevertRectTransform(transformSO);
                    }
                }
            }
        }

        private static void RevertGameObject(SerializedObject gameObjectSO)
        {
            if (RevertDefaultOverridesSettings.RevertName.value) PrefabUtility.RevertPropertyOverride(gameObjectSO.FindProperty("m_Name"), InteractionMode.AutomatedAction);
        }

        private static void RevertTransform(SerializedObject transformSO)
        {
            if (RevertDefaultOverridesSettings.RevertPosition.value) PrefabUtility.RevertPropertyOverride(transformSO.FindProperty("m_LocalPosition"), InteractionMode.AutomatedAction);
            if (RevertDefaultOverridesSettings.RevertRotation.value) PrefabUtility.RevertPropertyOverride(transformSO.FindProperty("m_LocalRotation"), InteractionMode.AutomatedAction);
            if (RevertDefaultOverridesSettings.RevertRotation.value) PrefabUtility.RevertPropertyOverride(transformSO.FindProperty("m_LocalEulerAnglesHint"), InteractionMode.AutomatedAction);
        }

        private static void RevertRectTransform(SerializedObject transformSO)
        {
            if (RevertDefaultOverridesSettings.RevertAnchorMin.value) PrefabUtility.RevertPropertyOverride(transformSO.FindProperty("m_AnchorMin"), InteractionMode.AutomatedAction);
            if (RevertDefaultOverridesSettings.RevertAnchorMax.value) PrefabUtility.RevertPropertyOverride(transformSO.FindProperty("m_AnchorMax"), InteractionMode.AutomatedAction);
            if (RevertDefaultOverridesSettings.RevertAnchoredPosition.value) PrefabUtility.RevertPropertyOverride(transformSO.FindProperty("m_AnchoredPosition"), InteractionMode.AutomatedAction);
            if (RevertDefaultOverridesSettings.RevertSizeDelta.value) PrefabUtility.RevertPropertyOverride(transformSO.FindProperty("m_SizeDelta"), InteractionMode.AutomatedAction);
            if (RevertDefaultOverridesSettings.RevertPivot.value) PrefabUtility.RevertPropertyOverride(transformSO.FindProperty("m_Pivot"), InteractionMode.AutomatedAction);
        }
    }
}
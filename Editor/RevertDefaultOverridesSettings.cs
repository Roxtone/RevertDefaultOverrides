using UnityEditor;
using UnityEditor.SettingsManagement;

namespace Roxtone.RevertDefaultOverrides
{
    internal static class RevertDefaultOverridesSettings
    {
        [UserSetting("Game Object", "Name")]
        public static readonly UserSetting<bool> RevertName = new(RevertDefaultOverridesSettings.Instance, "Name", true, SettingsScope.Project);
        [UserSetting("Transform", "Position")]
        public static readonly UserSetting<bool> RevertPosition = new(RevertDefaultOverridesSettings.Instance, "Position", true, SettingsScope.Project);
        [UserSetting("Transform", "Rotation")]
        public static readonly UserSetting<bool> RevertRotation = new(RevertDefaultOverridesSettings.Instance, "Rotation", true, SettingsScope.Project);
        [UserSetting("Rect Transform", "Anchor Min")]
        public static readonly UserSetting<bool> RevertAnchorMin = new(RevertDefaultOverridesSettings.Instance, "AnchorMin", true, SettingsScope.Project);
        [UserSetting("Rect Transform", "Anchor Max")]
        public static readonly UserSetting<bool> RevertAnchorMax = new(RevertDefaultOverridesSettings.Instance, "AnchorMax", true, SettingsScope.Project);
        [UserSetting("Rect Transform", "Anchored Position")]
        public static readonly UserSetting<bool> RevertAnchoredPosition = new(RevertDefaultOverridesSettings.Instance, "AnchoredPosition", true, SettingsScope.Project);
        [UserSetting("Rect Transform", "Size Delta")]
        public static readonly UserSetting<bool> RevertSizeDelta = new(RevertDefaultOverridesSettings.Instance, "SizeDelta", true, SettingsScope.Project);
        [UserSetting("Rect Transform", "Pivot")]
        public static readonly UserSetting<bool> RevertPivot = new(RevertDefaultOverridesSettings.Instance, "Pivot", true, SettingsScope.Project);

        private static Settings instance;

        internal static Settings Instance
        {
            get
            {
                instance ??= new Settings("com.github.roxtone.revertdefaultoverrides");
                return instance;
            }
        }

        [SettingsProvider]
        private static SettingsProvider CreateSettingsProvider()
        {
            return new UserSettingsProvider("Preferences/Revert Default Overrides", Instance, new[] { typeof(RevertDefaultOverridesSettings).Assembly });
        }
    }
}
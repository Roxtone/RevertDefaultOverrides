namespace Roxtone.RevertDefaultOverrides
{
    public static class RevertDefaultOverridesInput
    {
        public static bool DontRevertModifier
        {
            get
            {
#if ENABLE_INPUT_SYSTEM
                return UnityEngine.InputSystem.Keyboard.current.ctrlKey.isPressed;
#else
                return false;
#endif
            }
        }
    }
}
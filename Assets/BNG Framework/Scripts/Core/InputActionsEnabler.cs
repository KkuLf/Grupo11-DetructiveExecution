using UnityEngine;
using UnityEngine.InputSystem;

public class InputActionsEnabler : MonoBehaviour
{
    public InputActionAsset inputActions;

    void OnEnable()
    {
        if (inputActions != null)
            inputActions.Enable();
    }

    void OnDisable()
    {
        if (inputActions != null)
            inputActions.Disable();
    }
}

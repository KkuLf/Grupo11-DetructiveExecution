using UnityEngine;
using UnityEngine.InputSystem;

public class InputActionsEnabler : MonoBehaviour
{
    public InputActionAsset inputActions;

    void Update()
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

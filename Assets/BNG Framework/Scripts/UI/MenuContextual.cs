using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class MenuControllerVR : MonoBehaviour
{
    public GameObject menuCanvas;   // Canvas del menú
    private bool menuAbierto = false;

    // Acción asignada en el Input Actions (ejemplo "MenuButton")
    public InputActionProperty menuButtonAction;

    private void OnEnable()
    {
        menuButtonAction.action.performed += ToggleMenu;
        menuButtonAction.action.Enable();
    }

    private void OnDisable()
    {
        menuButtonAction.action.performed -= ToggleMenu;
        menuButtonAction.action.Disable();
    }

    private void ToggleMenu(InputAction.CallbackContext context)
    {
        menuAbierto = !menuAbierto;
        menuCanvas.SetActive(menuAbierto);

        if (menuAbierto)
        {
            // Posición y rotación lógica
            // Ejemplo: frente a la mano o frente al jugador
        }
    }
}


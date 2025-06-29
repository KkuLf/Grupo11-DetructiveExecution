using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class MenuControllerVR : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] GameObject menuCanvas;      
    [SerializeField] Transform followTarget;     
    [SerializeField] float distance = 0.5f;      

    [Header("Input (Input System)")]
    public InputActionProperty menuButtonAction;

    bool menuAbierto;

    void OnEnable()
    {
        menuButtonAction.action.performed += OnMenuPressed;
        menuButtonAction.action.Enable();
    }
    void OnDisable()
    {
        menuButtonAction.action.performed -= OnMenuPressed;
        menuButtonAction.action.Disable();
    }

    void OnMenuPressed(InputAction.CallbackContext _) => ToggleMenu();

    void ToggleMenu()
    {
        menuAbierto = !menuAbierto;
        menuCanvas.SetActive(menuAbierto);
        if (menuAbierto) ColocarFrenteAlJugador();  
    }

    void LateUpdate()
    {
        if (menuAbierto) ColocarFrenteAlJugador();   
    }

    void ColocarFrenteAlJugador()
    {
        if (followTarget == null) return;
        Vector3 pos = followTarget.position + followTarget.forward * distance;
        Quaternion rot = Quaternion.LookRotation(followTarget.forward, Vector3.up);
        menuCanvas.transform.SetPositionAndRotation(pos, rot);
    }
}


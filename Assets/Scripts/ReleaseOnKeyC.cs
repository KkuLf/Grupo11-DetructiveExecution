using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ReleaseOnKeyC : MonoBehaviour
{
    XRGrabInteractable _grab;
    XRBaseInteractor _holdingInteractor;

    void Awake() => _grab = GetComponent<XRGrabInteractable>();

    void Update()
    {
        var kb = Keyboard.current;

        if (_holdingInteractor != null && !_grab.isSelected)
            _holdingInteractor = null;

        if (kb.gKey.wasPressedThisFrame && _holdingInteractor == null)
        {
            var interactor = FindInteractor();
            if (interactor != null)
            {
                interactor.StartManualInteraction((IXRSelectInteractable)_grab);
                _holdingInteractor = interactor;
            }
        }

        if (kb.cKey.wasPressedThisFrame && _holdingInteractor != null)
        {
            _holdingInteractor.EndManualInteraction();
            _holdingInteractor = null;
        }
    }

    XRBaseInteractor FindInteractor()
    {
        foreach (var h in _grab.interactorsHovering)
            if (h is XRBaseInteractor xr) return xr;
        foreach (var s in _grab.interactorsSelecting)
            if (s is XRBaseInteractor xr) return xr;
        return null;
    }
}

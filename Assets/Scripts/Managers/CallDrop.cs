using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SmokeAndDeactivate : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] ParticleSystem smokeEffect;
    [SerializeField] GameObject objectToDisable;
    [SerializeField] float delayBeforeDisable = 0f;

    bool alreadyPressed = false;

    public void TriggerSequence()
    {
        if (alreadyPressed) return;          
        alreadyPressed = true;              

        if (smokeEffect != null) smokeEffect.Play();
        StartCoroutine(DisableLater());
    }

    IEnumerator DisableLater()
    {
        yield return new WaitForSeconds(delayBeforeDisable);
        if (objectToDisable != null) objectToDisable.SetActive(false);
    }
}

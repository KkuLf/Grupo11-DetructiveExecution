using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SmokeAndDeactivate : ObjectWithInteraction
{
    [Header("Referencias")]
    [SerializeField] ParticleSystem smokeEffect;
    [SerializeField] GameObject objectToEnable;
    [SerializeField] float delayBeforeEnable = 1f;

    bool alreadyPressed = false;

    public void TriggerSequence()
    {
        if (alreadyPressed) return;          
        alreadyPressed = true;              

        if (smokeEffect != null) smokeEffect.Play();
        StartCoroutine(EnableLater());
    }

    IEnumerator EnableLater()
    {
        yield return new WaitForSeconds(delayBeforeEnable);

        if (objectToEnable != null)
            objectToEnable.SetActive(true);   // ? AHORA se enciende
    }
}

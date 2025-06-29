using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagedUpdateBehavior : MonoBehaviour
{
    private int i;
    protected virtual void Start()
    {
        UpdateManager.instance.OnLightUpdate += LightUpdate;
    }
    // Update is called once per frame
    public void LightUpdate()
    {
        if (enabled)
        {
            CustomLightUpdate();
        }
    }

    protected virtual void CustomLightUpdate() { }

    protected virtual void OnDestroy()
    {
        UpdateManager.instance.OnLightUpdate -= LightUpdate;
    }
}

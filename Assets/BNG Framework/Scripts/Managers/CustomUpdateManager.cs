using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : MonoBehaviour
{
    public static UpdateManager instance;
    public event Action OnLightUpdate;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Early return to stop any updates when the game is paused
        if (Time.timeScale == 0)
            return;
        OnLightUpdate?.Invoke();
    }
}

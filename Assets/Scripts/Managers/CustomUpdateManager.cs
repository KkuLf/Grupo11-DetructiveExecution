using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomUpdateManager : MonoBehaviour
{
    private static List<IUpdateManager> _updateManagers = new List<IUpdateManager>();

    void Update()
    {
        foreach (var updater in _updateManagers)
        {
            updater.CustomUpdate();
        }
    }

    public static void RegisterUpdate(IUpdateManager newManager)
    {
        if (!_updateManagers.Contains(newManager))
        {
            _updateManagers.Add(newManager);
        }
    }

    public static void UnregisterUpdate(IUpdateManager newManager)
    {
        _updateManagers.Remove(newManager);
    }
}


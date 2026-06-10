using UnityEngine;

static class SimulatorBootstrap
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void Init()
    {
#if UNITY_STANDALONE && !UNITY_EDITOR
        var reference = Resources.Load<SimulatorReference>("SimulatorReference");
        if (reference != null && reference.prefab != null)
            Object.Instantiate(reference.prefab);
#endif
    }
}

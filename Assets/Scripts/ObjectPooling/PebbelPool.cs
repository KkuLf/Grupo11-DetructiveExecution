using UnityEngine;
using UnityEngine.Pool;

public class PebbelPool : ObjectWithInteraction
{
    [SerializeField] private Pebbel pebbelPrefab;

    protected ObjectPool<Pebbel> _pool;
    public float _bulletSpeed;
    public Transform _spawnPoint;

    private void Awake()
    {
        _pool = new ObjectPool<Pebbel>(CreatePebbel, null, OnPutBackInPool, defaultCapacity: 10);
    }

    private void OnPutBackInPool(Pebbel pebbel)
    {
        pebbel.gameObject.SetActive(false);
    }

    private Pebbel CreatePebbel()
    {
        var zone = Instantiate(pebbelPrefab);

        return zone;
    }

    public void SpawnPebbel()
    {
        var pebbel = _pool.Get();

        pebbel.Init(_spawnPoint, _bulletSpeed);
    }
}

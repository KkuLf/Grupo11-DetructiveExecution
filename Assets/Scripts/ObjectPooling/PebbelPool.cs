using UnityEngine;
using UnityEngine.Pool;



public class PebbelPool : MonoBehaviour
{
    [SerializeField] private Pebbel pebbelPrefab;

    private Pebbel[] _pebbels; // Array para almacenar balas preinstanciadas
    protected ObjectPool<Pebbel> _pool;
    public float _bulletSpeed;
    public Transform _spawnPoint;

    private void Awake()
    {
        int poolSize = 10;  // Definir un tamaño máximo para el pool de balas
        _pebbels = new Pebbel[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            _pebbels[i] = Instantiate(pebbelPrefab);  // Instanciamos las balas solo una vez
            _pebbels[i].gameObject.SetActive(false);   // Inicialmente las balas están inactivas
        }

        // Creamos el pool utilizando el array
        _pool = new ObjectPool<Pebbel>(
            () => GetAvailablePebbel(),  // Método para obtener una bala disponible
            OnPutBackInPool,
            OnTakeFromPool,
            maxSize: poolSize
        );
    }

    private void OnTakeFromPool(Pebbel pebbel)
    {
        pebbel.gameObject.SetActive(true);  // Habilitamos la bala cuando la obtenemos del pool
    }

    private void OnPutBackInPool(Pebbel pebbel)
    {
        pebbel.gameObject.SetActive(false); // Deshabilitamos la bala cuando la regresamos al pool
    }

    private Pebbel GetAvailablePebbel()
    {
        foreach (var pebbel in _pebbels)
        {
            if (!pebbel.gameObject.activeSelf)
            {
                return pebbel;
            }
        }
        return null;
    }

    public void SpawnPebbel()
    {
        var pebbel = _pool.Get();  // Obtiene una bala del pool
        if (pebbel != null)
        {
            pebbel.Init(_spawnPoint, _bulletSpeed);  // Inicializa la bala
        }
    }
}

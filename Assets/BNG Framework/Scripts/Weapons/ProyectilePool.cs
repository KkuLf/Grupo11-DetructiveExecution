using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : ManagedUpdateBehavior
{
    public static ProjectilePool Instance;

    public GameObject projectilePrefab;
    public int poolSize = 20;

    private Queue<GameObject> projectilePool = new Queue<GameObject>();

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(projectilePrefab);
            obj.SetActive(false);
            projectilePool.Enqueue(obj);
        }
    }

    public GameObject GetProjectile()
    {
        if (projectilePool.Count > 0)
        {
            GameObject proj = projectilePool.Dequeue();
            proj.SetActive(true);
            return proj;
        }
        else
        {
            GameObject extra = Instantiate(projectilePrefab);
            return extra;
        }
    }

    public void ReturnProjectile(GameObject proj)
    {
        proj.SetActive(false);
        projectilePool.Enqueue(proj);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolController : ObjectWithInteraction
{
    [SerializeField] private GameObject bulletPrefab;   // The bullet prefab to instantiate
    [SerializeField] private Transform firePoint;       // Where the bullets spawn from
    [SerializeField] private float bulletSpeed;   // Speed of the bullet

    private PebbelPool bulletPool;
    private bool canShoot;

    private void Awake()
    {
        bulletPool = new PebbelPool();
        bulletPool._bulletSpeed = bulletSpeed;
        bulletPool._spawnPoint = firePoint;

        canShoot = true;
    }

    public void Shoot()
    {
        if (canShoot)
        {
            bulletPool.SpawnPebbel();
            canShoot = false;
            StartCoroutine("TimeBetweenShots");
        }

    }

    IEnumerator TimeBetweenShots()
    {
        yield return new WaitForSeconds(.4f);
        canShoot = true;
    }
}

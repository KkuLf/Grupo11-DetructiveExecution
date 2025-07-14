using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Pebbel : ObjectWithInteraction
{
    private bool _isActive = false;

    private ObjectPool<Pebbel> _pool;

    public void Init(ObjectPool<Pebbel> pool, Transform shootingPoint, float bulletSpeed)
    {
        transform.position = shootingPoint.position;
        transform.rotation = shootingPoint.rotation;

        _isActive = true;
        gameObject.SetActive(_isActive);

        _pool = pool;

        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Reset any previous velocity or rotation
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            // Add force to the bullet to make it move
            rb.AddForce(shootingPoint.forward * bulletSpeed, ForceMode.Impulse);
        }

        StartCoroutine("StartPebbelLifeTime");
    }

    IEnumerator StartPebbelLifeTime()
    {
        yield return new WaitForSeconds(2f);

        if (_isActive)
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        _isActive = false;
        _pool.Release(this);
    }
}

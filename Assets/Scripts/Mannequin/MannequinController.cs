using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MannequinController : NeedCustomUpdateObject
{
    [SerializeField] private bool Patrol = true;
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private float patrolSpeed = 2f;

    private int currentPatrolIndex = 0;
    private bool initialized = false;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        if (initialized) return;

        Patrol = true;
       // ScoreManager.Instance.AddScore(1);
        initialized = true;

        
    }

    public override void CustomUpdate()
    {
        if (!initialized)
            Initialize();

        if (Patrol)
            PatrolMannequin();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pebbels"))
        {
            ScoreManager.Instance.AddScore(-1);
            gameObject.SetActive(false);
        }
    }

    private void PatrolMannequin()
    {
        if (patrolPoints == null || patrolPoints.Length == 0)
            return;

        Transform targetPoint = patrolPoints[currentPatrolIndex];
        Vector3 direction = (targetPoint.position - transform.position).normalized;

        float step = patrolSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, step);

        

        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }

        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }
    }
}

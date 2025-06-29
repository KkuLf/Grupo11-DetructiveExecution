using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MannequinController : NeedCustomUpdateObject
{
    [SerializeField] private bool Patrol = false;
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private float patrolSpeed = 2f;

    private int currentPatrolIndex = 0;
    private void Start()
    {
        ScoreManager.Instance.AddScore(1);
    }
    // Update is called once per frame
    public override void CustomUpdate()
    {
        if (Patrol)
            PatrolMannequin();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pebbels")
        {
            ScoreManager.Instance.AddScore(-1);
            gameObject.SetActive(false);
        }
    }

    public void PatrolMannequin()
    {
        if (patrolPoints == null || patrolPoints.Length == 0)
            return;

        Transform targetPoint = patrolPoints[currentPatrolIndex];
        Vector3 direction = (targetPoint.position - transform.position).normalized;
        float step = patrolSpeed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, step);

        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }
    }
}

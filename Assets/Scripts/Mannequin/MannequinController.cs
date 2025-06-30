using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MannequinController : NeedCustomUpdateObject
{
    [SerializeField] private bool Patrol = true; // Ahora activado por defecto
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private float patrolSpeed = 2f;

    private int currentPatrolIndex = 0;

    private void Start()
    {
        // Asegura que patrulle automáticamente
        Patrol = true;
        ScoreManager.Instance.AddScore(1);
    }

    public override void CustomUpdate()
    {
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

        // Movimiento
        float step = patrolSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, step);

        // Rotación suave hacia el punto
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }

        // Si llegó al punto, cambia al siguiente
        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }
    }
}

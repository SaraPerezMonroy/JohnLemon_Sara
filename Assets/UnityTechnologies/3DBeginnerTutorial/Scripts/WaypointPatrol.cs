using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints; // Array con los puntos a los que ir, aunque realmente solo habrá dos
    int m_CurrentWaypointIndex;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        if(navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length; // Añade uno al índice actual, pero si ese incremento hace que el índice sea igual al número de elementos en el array de waypoints, entonces en su lugar establécelo en cero
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position); 
        }
    }
}

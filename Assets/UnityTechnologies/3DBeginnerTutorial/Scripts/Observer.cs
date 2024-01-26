using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    bool m_IsPlayerInRange;
    public GameEnding gameEnding; 



    void Update()
    {
        if(m_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up; // Hacemos un rayo para que calcule desde el jugador hasta la gárgola, con un poquito de altura para que se vea
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if(Physics.Raycast(ray, out raycastHit)) // Confirmamos que ve algo 
            {
                if(raycastHit.collider.transform == player) // Confirmar que el rayo que lanzo choca con el player, no hay nada en medio entre los ojos de la gárgola y el player
                {

                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }
}

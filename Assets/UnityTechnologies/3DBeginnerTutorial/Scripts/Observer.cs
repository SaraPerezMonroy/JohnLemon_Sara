using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    bool m_IsPlayerInRange;
    public GameEnding gameEnding;
    float m_Timer = 0f;

    public AudioSource alertaAudio;
    bool m_HasAudioPlayed;

    [SerializeField]
    public GameObject exclamacion;


    void Start()
    {
        alertaAudio = GetComponent<AudioSource>(); // Acceder al audio source
        exclamacion.SetActive(false); // Exclamaciones de los enemigos desactivadas
        m_HasAudioPlayed = false; // Audio en falso, no se reproduce al iniciar
    }

    void FixedUpdate()
    {
        if(m_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up; 
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if(Physics.Raycast(ray, out raycastHit)) 
            {
                if (raycastHit.collider.transform == player) 
                {
                    exclamacion.SetActive(true); // (Modificación 3) Aparece una exclamación encima del enemigo al verte
                    m_Timer += Time.deltaTime;                    
                    if(!m_HasAudioPlayed) // (Modificación 2) Sonido tindeck_1
                    {
                        alertaAudio.Play(); 
                        m_HasAudioPlayed = true;
                    }

                    if (m_Timer > 2f) // (Modificación 1) Pasan dos segundos antes de pillarte
                    {
                        gameEnding.CaughtPlayer(); 
                    }
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
        if (other.transform == player) 
        {
            m_IsPlayerInRange = false;
            m_Timer = 0f;
            exclamacion.SetActive(false);
            m_HasAudioPlayed = false;
        }
    }
}

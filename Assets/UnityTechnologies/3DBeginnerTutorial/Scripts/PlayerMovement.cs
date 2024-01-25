using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator m_Animator;
   
    Vector3 m_Movement;
    public float turnSpeed = 20f;
    Rigidbody m_Rigidbody;
    Quaternion m_Rotation = Quaternion.identity; // Esto sirve como ponerle a un vector 0f, para que deje de girar, pero con lo cuaterniones es diferente y en vez de poner 0, pondremos .identity (consultar apuntes)

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>(); // Acceder al animator
        m_Rigidbody = GetComponent<Rigidbody>(); // Acceder al rigidbody
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize(); // Arreglar lo del teorema de pitágoras, normalizándolo para que no se mueva más rápido

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f); // Si no es 0 o aproximadamente 0, lo niega usando el = !
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput; // Lo juntamos en una sola variable, si se mueve en horizontal o vertical ya está caminando
        m_Animator.SetBool("IsWalking", isWalking); // cambiamos el animator a walking

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);  // Actualiza el valor de la rotación teniendo en cuenta el movimiento de nuestro quaternion


    }

    void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);

    }


}

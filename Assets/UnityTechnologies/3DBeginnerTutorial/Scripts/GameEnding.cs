using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    float m_Timer;

    public GameObject player;

    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroup;

    bool m_IsPlayerAtExit;
    bool m_IsPlayerCaught;

    void Update()
    {
        if(m_IsPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false);
        }
        else if(m_IsPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true);
        }
    }

    public void CaughtPlayer() // Hacemos la función pública, pero el IsPlayerCaught sigue siendo privado, no todo el mundo necesita saber si lo atrapamos :)
    {
        m_IsPlayerCaught = true; 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }

    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart)
    {
        m_Timer += Time.deltaTime;

        imageCanvasGroup.alpha = m_Timer / fadeDuration;

        if(m_Timer > fadeDuration + displayImageDuration)
        {
            if(doRestart)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
        }
    }
}

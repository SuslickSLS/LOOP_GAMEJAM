using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathUI : MonoBehaviour
{
    [SerializeField] 
    private Death death;

    [SerializeField]
    private GameObject deathUI;

    [SerializeField]
    private Button buttonRestart;


    private void OnEnable()
    {
        buttonRestart.onClick.AddListener(RestartGame);
        death.deathPlayer += Death;
    }

    private void OnDisable()
    {
        death.deathPlayer -= Death;
        buttonRestart.onClick.RemoveListener(RestartGame);
    }

    private void Death()
    {
        deathUI.SetActive(true);
        Time.timeScale = 0;
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

}

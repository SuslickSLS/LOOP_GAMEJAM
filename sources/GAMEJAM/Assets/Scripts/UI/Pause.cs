using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using StarterAssets;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private Button _buttonReturn;

    [SerializeField]
    private Button _buttonAgain;

    [SerializeField]
    private Button _buttonExit;

    [SerializeField]
    private GameObject _uiPause;


    private bool isPause = false;

    private void OnEnable()
    {
        _buttonAgain.onClick.AddListener(Again);
        _buttonExit.onClick.AddListener(Exit);
        _buttonReturn.onClick.AddListener(Return);
    }
    private void OnDisable()
    {
        _buttonAgain.onClick.RemoveListener(Again);
    }

 


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;

            if (isPause)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                _uiPause.SetActive(true);
                Time.timeScale = 0f;

            }
        }
    }

    private void Again()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    private void Exit()
    {
        Application.Quit();
    }

    private void Return()
    { 
        Cursor.lockState = CursorLockMode.Locked;
        _uiPause.SetActive(false);
        isPause = false;
        Time.timeScale = 1f;
    }

    public bool IsPause()
    {
        return isPause;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [SerializeField] 
    private Button _btnStart;

    [SerializeField] 
    private Button _btnExit;

    private void OnEnable()
    {
        _btnStart.onClick.AddListener(StartGame);
        _btnExit.onClick.AddListener(CloseGame);
    }

    private void OnDisable()
    {
        _btnStart.onClick.RemoveListener(StartGame);
        _btnExit.onClick.RemoveListener(CloseGame);
    }


    private void StartGame()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(1);
    }
    private void CloseGame()
    {
        Application.Quit();
    }
}

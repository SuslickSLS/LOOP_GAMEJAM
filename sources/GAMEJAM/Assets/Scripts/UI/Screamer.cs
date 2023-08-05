using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Kino;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Screamer : MonoBehaviour
{
    [SerializeField]
    private GameObject _canvasScreamer;
    
    [SerializeField]
    private GameObject _chat;

    [SerializeField]
    private GameObject _screamerUI;

    [SerializeField]
    private GameObject _subUI;

    [SerializeField]
    private DigitalGlitch _glich;

    [SerializeField]
    private EnemyGun _enemy;

    public event UnityAction asuPlay;

    private void OnEnable()
    {
        _enemy.deathBOSS += ScreamerStart;
    }

    private void OnDisable()
    {
        _enemy.deathBOSS -= ScreamerStart;
    }



    private void ScreamerStart()
    {
        StartCoroutine(ScreamerCoroutine());
    }

    private IEnumerator ScreamerCoroutine()
    {
        _glich.intensity = 0.256f;
        _canvasScreamer.SetActive(true);

        yield return new WaitForSeconds(1);

        _subUI.SetActive(true);

        yield return new WaitForSeconds(1);

        asuPlay?.Invoke();

        yield return new WaitForSeconds(4);

        _screamerUI.GetComponent<Image>().color = Color.black;
        _screamerUI.GetComponent<AudioSource>().mute = false;

        _subUI.SetActive(false);
        //_chat.SetActive(false);

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(2);
        _glich.intensity = 0;
    }

}

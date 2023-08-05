using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class FinalGame : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector director;

    [SerializeField]
    private GameObject _light;
    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private GameObject _Enemy;

    [SerializeField]
    private bool _isActiveEnemy;

    [SerializeField]
    private bool _isActive;

    private bool _isActiveTrigger = true;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_isActiveTrigger)
            {
                _player.SetActive(false);
                _Enemy.SetActive(_isActiveEnemy);

                if (_isActive)
                {
                    _light.GetComponent<Light>().color = Color.white;
                    _light.GetComponent<Light>().intensity = 1;
                    _light.GetComponent<Light>().shadows = LightShadows.None;
                    _light.transform.eulerAngles = new Vector3(-325.4f, 55.3f, 0);
                    //_light.SetActive(false);
                }


                _isActiveTrigger = false;

                StartCoroutine(FinalCutScene());
            }
        }
    }


    private IEnumerator FinalCutScene()
    {
        director.Play();

        yield return new WaitForSeconds(16);

        SceneManager.LoadScene(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TrimmerCutScene : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector director;

    [SerializeField]
    private GameObject _light;

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
            if(_isActiveTrigger)
            {

                _Enemy.SetActive(_isActiveEnemy);

                if (_isActive)
                {
                    _light.SetActive(false);
                }


                _isActiveTrigger = false;

                director.Play();
            }
        }
    }
}

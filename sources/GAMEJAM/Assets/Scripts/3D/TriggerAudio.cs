using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerAudio : MonoBehaviour
{
    [SerializeField]
    private GameObject _paleyr;

    [SerializeField]
    private TMP_Text _uiText;

    [SerializeField]
    private GameObject _UI;

    [SerializeField]
    private string _text;

    [SerializeField]
    private bool _isRemove;

   
    [SerializeField]
    private float _seconds;

    [SerializeField]
    private AudioClip _clip;


    private AudioSource _audio;
    private bool _isActive = true;

    private void Awake()
    {
        _audio = _paleyr.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(_isActive)
        {
            _isActive = false;
            if (other.transform.CompareTag("Player"))
            {
                _uiText.text = _text;
                StartCoroutine(Corotine());
            }
        }
    }

    private IEnumerator Corotine()
    {
        _UI.SetActive(true);
        _audio.clip = _clip;
        _audio.Play();
        

        yield return new WaitForSeconds(_seconds);

        _UI.SetActive(false);
        _audio.Stop();

        if (_isRemove)
        {
            this.gameObject.SetActive(false);
        }
    }

}

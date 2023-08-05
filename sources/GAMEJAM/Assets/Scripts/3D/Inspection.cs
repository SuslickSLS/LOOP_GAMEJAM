using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inspection : MonoBehaviour
{
    [SerializeField]
    private string _text;

    [SerializeField]
    private AudioClip _clip;

    [SerializeField]
    private AudioSource _source;

    [SerializeField]
    private GameObject _ui;

    [SerializeField]
    private TMP_Text _textUI;

    [SerializeField]
    private int _timeClose;

    [SerializeField]
    private bool _isRemove;

    public void Talk()
    {
        StartCoroutine(TalkCoroutine());
    }

    private IEnumerator TalkCoroutine()
    {
        _source.clip = _clip;
        _source.Play();

        _ui.SetActive(true);
        _textUI.text = _text;

        yield return new WaitForSeconds(_timeClose);

        _ui.SetActive(false);

        _source.clip = null;
        if(_isRemove)
        {
            this.gameObject.SetActive(false);
        }
    }
}
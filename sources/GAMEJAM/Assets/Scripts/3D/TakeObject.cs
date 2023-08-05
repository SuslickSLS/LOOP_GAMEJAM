using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TakeObject : MonoBehaviour
{
    [SerializeField]
    private Vector3 _objectPlace;

    [SerializeField]
    private Transform _playerTransform;

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


    public void Take()
    {
        StartCoroutine(TakeCoroutine());
    }

    private IEnumerator TakeCoroutine()
    {
        _source.clip = _clip;
        _source.Play();
        Moving();

        _ui.SetActive(true);
        _textUI.text = _text;

        yield return new WaitForSeconds(_timeClose);

        _ui.SetActive(false);

        _source.clip = null;
    }


    private void Moving()
    {
        this.gameObject.GetComponent<HintScript>().enabled = false;
        this.gameObject.GetComponent<MeshCollider>().enabled = false;
        this.gameObject.transform.parent = _playerTransform;
        this.gameObject.transform.localPosition = _objectPlace;
        this.gameObject.transform.localEulerAngles = new Vector3(0f, -178.473f, 0f);
        //this.gameObject.transform.rotation = _objectRotation;
    }
}

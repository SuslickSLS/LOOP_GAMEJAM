using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitcherScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _panel;

    private Animator _anim;
    private bool _isActive = false;

    public event UnityAction deathBOSS;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _isActive == true)
        {
            _anim.SetTrigger("IsSwith");
            deathBOSS?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            _panel.SetActive(true);
            _isActive = true;
        }
    }

    

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isActive = false;
        _panel.SetActive(false);
    }
}

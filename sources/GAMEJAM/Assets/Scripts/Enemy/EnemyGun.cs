using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyGun : MonoBehaviour
{
    [SerializeField]
    private SwitcherScript _switch;
    [SerializeField]
    private AudioClip _clipDeath;
    [SerializeField]
    private GameObject _panel;

    private Animator _anim;
    private Animator _animPanel;
    private AudioSource _audio;

    public event UnityAction deathBOSS;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
        _animPanel = _panel.gameObject.GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _switch.deathBOSS += Death;
    }

    private void OnDisable()
    {
        _switch.deathBOSS -= Death;
    }

    private void Death()
    {
        _audio.clip = _clipDeath;
        StartCoroutine(DeathCorrotine());        
    }

    private IEnumerator DeathCorrotine()
    {
        _animPanel.SetTrigger("DeathBOSS");

        yield return new WaitForSeconds(1f);

        _anim.SetTrigger("Death");
        _audio.Play();

        yield return new WaitForSeconds(2.5f);

        _audio.Stop();
        deathBOSS?.Invoke();
        this.gameObject.SetActive(false);
    }
}

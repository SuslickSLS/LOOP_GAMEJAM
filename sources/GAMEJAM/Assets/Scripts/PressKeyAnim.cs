using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressKeyAnim : MonoBehaviour
{
    [SerializeField]
    private PlayerMover _player;

    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _player.pressKey += Play;
    }

    private void OnDisable()
    {
        _player.pressKey -= Play;
    }

    private void Play()
    {
       _anim.SetTrigger("Play");
    }
}

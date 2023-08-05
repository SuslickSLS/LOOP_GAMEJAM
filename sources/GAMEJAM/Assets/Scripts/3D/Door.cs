using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    private bool isOpened = true;

    public void Open()
    {
        _animator.SetBool("IsOpened", isOpened);
        isOpened = !isOpened;
    }
}

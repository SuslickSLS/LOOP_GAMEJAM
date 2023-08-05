using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Death : MonoBehaviour
{

    public event UnityAction deathPlayer;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("DeathZone") || collision.gameObject.CompareTag("Enemy"))
        {
            deathPlayer?.Invoke();
        }
    }
}

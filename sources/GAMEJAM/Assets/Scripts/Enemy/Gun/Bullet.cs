using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Можно добавить анимацию
        Die();
    }
    private void Die()
    {
        gameObject.SetActive(false);
    }
}

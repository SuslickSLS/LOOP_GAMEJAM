using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField]
    private VectorValue vectorValue;

    [SerializeField]
    private Vector3 vector3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            vectorValue.PositionPlayer = vector3;
        }
    }
}

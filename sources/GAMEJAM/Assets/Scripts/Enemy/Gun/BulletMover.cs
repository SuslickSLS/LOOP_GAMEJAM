using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    [SerializeField]
    private float _speedEnemy;

    private void Update()
    {
        transform.Translate(Vector3.left * _speedEnemy * Time.deltaTime);
    }
}

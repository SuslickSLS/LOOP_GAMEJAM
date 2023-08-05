using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy3D : MonoBehaviour
{
    [SerializeField]
    private Transform _player;

    

    private NavMeshAgent _enemy;

    private void Start()
    {
        _enemy = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _enemy.destination = _player.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            Debug.Log("Смерть");
        }
    }
}

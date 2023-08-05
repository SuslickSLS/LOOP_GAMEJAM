using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBullet : ObjectPool
{
    [SerializeField]
    private GameObject playerPos;

    [SerializeField]
    private float agroDistansion;

    [SerializeField]
    private GameObject _prefabBullet;

    [SerializeField]
    private Transform _spawnPoint;

    [SerializeField]
    private float _secondsBetweenSpawn;

    [SerializeField]
    private float reloadTime;

    [SerializeField]
    private float timeShot;
    [SerializeField]
    private GameObject _gun;
    [SerializeField]
    private AudioClip _clip;

    private bool reload = false;
    private float _elapserTime = 0;
    private float time = 0;
    private AudioSource _audio;
    private AudioSource _audioGun;
    private Animator _anim;
    private bool isTalk;
    private bool isGun = true;

    private void Start()
    {
        Instalize(_prefabBullet);
        _audio = GetComponent<AudioSource>();
        _audioGun = _gun.GetComponent<AudioSource>();
        _audioGun.Stop();
        _anim = GetComponent<Animator>();
        _audio.clip = _clip;
        isTalk = true;
    }

    private void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, playerPos.transform.position);

        if(distToPlayer < agroDistansion)
        {

            _elapserTime += Time.deltaTime;
            time += Time.deltaTime;

            //Условие перезарядки и видимости игрока
            if (timeShot >= time)
            {
                if(isTalk)
                {
                    _audio.Play();
                    isTalk = false;
                }

                if (_elapserTime >= _secondsBetweenSpawn && reload == false)
                {
                    if (TryGetObject(out GameObject enemy))
                    {
                        _elapserTime = 0;

                        SetEnemy(enemy, _spawnPoint.position);
                    }
                }
            }
            else
            {
                reload = true;
                time = 0;
                _audio.Stop();
                _audioGun.Stop();
                _anim.enabled = false;
            }

            if(isGun)
            {
                _audioGun.Play();
                isGun = false;
            }

            if (reload)
            {
                if (_elapserTime >= reloadTime)
                {
                    reload = false;
                    time = 0;
                    isTalk = true;
                    isGun = true;
                    _anim.enabled = true;
                }
            }
        }
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }


}

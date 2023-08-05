using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private AudioClip clip;

    [SerializeField]
    private Vector3[] positions;
    


    private int currentTarget;
    private float postPosition;
    private float position;
    private bool isDeath = false;
    private SpriteRenderer sprite;
    private Animator anim;
    private CapsuleCollider2D deathTrigger;
    private Rigidbody2D rg;
    private AudioSource audio;


    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        deathTrigger = GetComponent<CapsuleCollider2D>();
        rg = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        position = gameObject.transform.position.x;
        postPosition = gameObject.transform.position.x;
        audio.clip = clip;
    }

    private void FixedUpdate()
    {
        if(!isDeath)
        {
            transform.position = Vector3.MoveTowards(transform.position, positions[currentTarget], speed * Time.fixedDeltaTime);

            if (transform.position == positions[currentTarget])
            {
                if (currentTarget < positions.Length - 1)
                {
                    currentTarget++;
                }
                else
                {
                    currentTarget = 0;
                }
            }

            position = gameObject.transform.position.x;

            if (position > postPosition)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }

            postPosition = position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DeathEnemyCoroutine());
        }
    }


    private IEnumerator DeathEnemyCoroutine()
    {
        isDeath = true;
        rg.bodyType = RigidbodyType2D.Static;
        deathTrigger.enabled = false;
        audio.Play();
        anim.SetTrigger("Death");

        yield return new WaitForSeconds(0.15f);
        
        sprite.enabled = false;

        yield return new WaitForSeconds(1);

        Destroy(this.gameObject);
    }
}
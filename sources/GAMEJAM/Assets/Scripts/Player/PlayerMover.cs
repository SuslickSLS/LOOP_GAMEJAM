using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMover : MonoBehaviour
{
    const float speedMultiplier = 50f; 

    [SerializeField]
    private GameObject Player;

    [SerializeField]
    private float speed;

    [SerializeField]
    private VectorValue playerSpawn;

    private float horizontal;
    private Rigidbody2D rd;
    private SpriteRenderer sprite;
    private float speedChange;
    private bool isJump = false;
    private bool isGround = true;
    private bool isRigth = true;
    private Animator _anim;

    public event UnityAction pressKey;

    private void Start()
    {
        Cursor.visible = false;
        gameObject.transform.position = playerSpawn.PositionPlayer;

        _anim = Player.GetComponent<Animator>();
        speedChange = 0;
        rd = Player.GetComponent<Rigidbody2D>();
        sprite = Player.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        horizontal =  Input.GetAxis("Horizontal");

        if(Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            isJump = true;
            _anim.SetTrigger("Jump");
            _anim.SetBool("isJump",true);
        }

        if(Input.anyKeyDown)
        {
            pressKey?.Invoke();
        }
    }

    private void FixedUpdate()
    {
        rd.velocity = new Vector2(horizontal * speed * speedMultiplier * Time.fixedDeltaTime, rd.velocity.y);
        
        if(isJump)
        {
            rd.AddForce(new Vector2(0f, 500f));
            isGround = false;
            isJump = false;
        }

        if(horizontal == 0 && isJump == false)
        {
            _anim.SetBool("IsRunning", false);
        }
        if (horizontal != 0 && isJump == false)
        {
            _anim.SetBool("IsRunning", true);
        }

        if(horizontal > 0f && !isRigth)
        {
            Flip();
        }
        else if( horizontal < 0f && isRigth)
        {
            Flip();
        }
    }

    private void Flip()
    {
        isRigth = !isRigth;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            _anim.SetBool("isJump", false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;

    private void Awake() {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    public float jumpPower;
    public float movePower;

    Vector3 movement;

    void FixedUpdate()
    {
        Move();
        Jump();
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;
            spriteRenderer.flipX = false;
        }

        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
            spriteRenderer.flipX = true;
        }

        transform.position += moveVelocity * movePower * Time.deltaTime;

        if (moveVelocity == Vector3.zero) // isWalking false
            anim.SetBool("isWalking", false);
        else // true
            anim.SetBool("isWalking", true);

    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.C)) {

        rigid.velocity = Vector2.zero;

        Vector2 jumpVelocity = new Vector2(0, jumpPower);
        rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy") {
            OnDamaged(collision.transform.position);
        }
    }

    void OnDamaged(Vector2 targetPos)
    {
        gameObject.layer = 13;
        spriteRenderer.color = new Color(1,1,1,0.8f);

        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        rigid.AddForce(new Vector2(dirc, 1)*3, ForceMode2D.Impulse);

        anim.SetTrigger("isAttacked");
        Invoke("OffDamaged", 0.5f);
    }

    void OffDamaged()
    {
        gameObject.layer = 12;
        spriteRenderer.color = new Color(1,1,1,1);
    }
}



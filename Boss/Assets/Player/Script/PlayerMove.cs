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

    // 플레이어 이동 관련(전주술/산양과 관련 X)

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
        if(Input.GetKeyDown(KeyCode.Z)) {

        rigid.velocity = Vector2.zero;

        Vector2 jumpVelocity = new Vector2(0, jumpPower);
        rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);

        }
    }
}



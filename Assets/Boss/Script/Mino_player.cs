using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mino_player : MonoBehaviour
{
    //public float Mino_power = 10;

    Animator anim;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // 보스 공격 피격
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "BossAttack") {
            OnDamaged(other.transform.position);
            print(other.gameObject.name + " 맞음!");

        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "BossAttack") {
            OnDamaged(other.transform.position);
            print(other.gameObject.name + " 맞음!");
        }
    }

    void OnDamaged(Vector2 targetPos)
    {
        //gameObject.layer = 13;
        spriteRenderer.color = new Color(1,0.5f,0.5f,0.8f);

        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        rigid.AddForce(new Vector2(dirc, 1)*3, ForceMode2D.Impulse);

        anim.SetTrigger("isAttacked");
        Invoke("OffDamaged", 0.5f);
    }
    void OffDamaged()
    {
        //gameObject.layer = 12;
        spriteRenderer.color = new Color(1,1,1,1);
    }
}

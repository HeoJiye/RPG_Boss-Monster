
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed;
    public float HP;

    public GameObject player;

    public int direction = 0;

    public GameObject enemy;

    public int index = -1;

    SpriteRenderer renderer;
    Transform transform;
    Animator animator;
    Rigidbody2D rigid;

    public bool isAttacked = false;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        transform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        rigid = gameObject.GetComponent<Rigidbody2D>();


        Invoke("Think", 3);
    }

    void Update() => Walk();
    

    void FixedUpdate()
    {
        // 지형 탐색
        Vector2 frontVec = new Vector2(rigid.position.x + direction*1.2f, rigid.position.y-1);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0,1,0));
        RaycastHit2D raycast = Physics2D.Raycast(frontVec, Vector3.down,1,LayerMask.GetMask("Platform"));
        
        // 낭떠러지면 방향 전환
        if(raycast.collider == null) direction *= -1;

        if(HP <= 0) {
            Destroy(enemy, 0.1f);
            EnemySpawn._instance.enemyCount--;
            EnemySpawn._instance.isSpawn[index] = false;
        }

    }

    void Think() {
        if(!isAttacked)
            direction = Random.Range(-1, 2);

        float nextThinkTime = Random.Range(2f, 5f);
        Invoke("Think", nextThinkTime);
    }
    
    void Walk() {
        // flipX 설정
        if(direction == 1) renderer.flipX = true;
        else if (direction == -1) renderer.flipX = false;

        // "이동" Bool 설정
        if(direction == 0) animator.SetBool("이동", false);
        else animator.SetBool("이동", true);

        this.transform.Translate(0.01f*direction*speed, 0, 0);
    }

    void OnTriggerEnter2D (Collider2D other) {
        if(other.gameObject.tag == "Player") {
            player = other.gameObject;
            animator.SetBool("이동", true);
        }
    }

    void OnTriggerStay2D (Collider2D other) {
        if(other.gameObject.tag == "Player") {
            float distanceX = player.transform.position.x - transform.position.x;
            float distanceY = player.transform.position.y - transform.position.y;
            
            if(distanceY < 2f && distanceY > -2f){
                // 추격
                if(distanceX > 2f) direction = 1;
                else if (distanceX < -2f) direction = -1;

                // 공격
                else {
                    direction = 0;
                    animator.SetTrigger("공격");
                }
            }
        }

    }

}

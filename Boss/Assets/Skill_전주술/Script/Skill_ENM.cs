using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_ENM : MonoBehaviour
{
    public GameObject skill;
    public float damage;
    Animator animator;
    Transform trans;

    GameObject enemy;

    SpriteRenderer ER;
    Animator EA;

    EnemyMove en;
    Mino_Hp mino;

    void Awake() {
        animator = GetComponent<Animator>();
        trans = GetComponent<Transform>();

        enemy = transform.parent.gameObject;

        ER = enemy.GetComponent<SpriteRenderer>();
        EA = enemy.GetComponent<Animator>();

        if(enemy.tag == "Enemy")
            en = enemy.GetComponent<EnemyMove>();
        else if(enemy.tag == "Boss") {
            mino = enemy.GetComponent<Mino_Hp>();
            trans.position -= new Vector3(0f, 2f, 5f);
        }
    }
    
    void Start() {
        animator.SetTrigger("skill");
        
        if(enemy.tag == "Enemy")
            EA.SetTrigger("피격");
     }

     void Update() {
        if(enemy.tag == "Enemy") {
            ER.color = new Color(1f, 0.5f, 0.5f, 0.4f);
            en.isAttacked = true;
            en.direction = 0;
        }
     }

    // 스킬 애니메이션 마지막에 이벤트 추가
    void remove()
    {
        if(enemy.tag == "Enemy") {
            // Enemy 피격 탈출
            ER.color = new Color(1f, 1f, 1f, 1f);
            en.isAttacked = false;
            en.HP -= damage;
        }
        else if(enemy.tag == "Boss") {
            mino.Attacked(damage);
        }        

        Destroy(skill);
    }
}

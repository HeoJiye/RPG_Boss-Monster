using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill_ENM : MonoBehaviour
{
    public GameObject skill;
    public KeyCode key;

    Animator anim;

     private void Awake() {
        anim = GetComponent<Animator>();
    }

     void Update() {
        // Player의 전주술 모션
        if(Input.GetKeyDown(key))
            anim.SetTrigger("전주술");

    }

    void OnTriggerStay2D (Collider2D other) {
        // 범위 내에 Enemy 존재하면
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Boss") {
            
            // 전주술 스킬 오브젝트 소환
            if(Input.GetKeyDown(key))
                Instantiate(skill, other.gameObject.transform);
        }
    }

}

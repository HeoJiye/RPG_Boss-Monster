using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mino_attack : MonoBehaviour
{
    //public GameObject[] attacks;

    string[] attackList;

    Animator anim;

    void Start() {
        anim = gameObject.GetComponent<Animator>();

        attackList = new string[] {"strikeDown", "bullAttack", "sweepAway", "Stun"};
        Invoke("random_attack", 5);
    }

    public void random_attack() {
        int num = Random.Range(0, 4);
        anim.SetTrigger(attackList[num]);
        Invoke("random_attack", 7);
    }
}

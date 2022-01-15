using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Minotaur : MonoBehaviour
{
    public Text health;

    public PolygonCollider2D collider;

    public GameObject[] reward;

    Animator anim;

    bool attack;

    float hp;

    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        health.text = "HP: " + hp;

        if(Input.GetKeyDown(KeyCode.A))
            anim.SetTrigger("Attack0");

        if(Input.GetKeyDown(KeyCode.S))
            anim.SetTrigger("Attack1");

        if(Input.GetKeyDown(KeyCode.D))
            anim.SetTrigger("Attack2");

        if(Input.GetKeyDown(KeyCode.F))
            anim.SetTrigger("Stun");

        if(Input.GetKeyDown(KeyCode.G)) {
            anim.SetTrigger("isAttacked");
            if(hp > 0) hp -= 10f;
        }

        if(hp <= 0) {
            anim.SetBool("isDie", true);
        }
    }

    public void Die() {
        int num = Random.Range(0, 3);
        Instantiate(reward[num], new Vector3(0f, 0f, 0f), Quaternion.identity);
        Destroy(gameObject);
    }

    public void layerUp() {
        transform.position -= new Vector3(0, 0, 5);
        //collider.enabled = true;
        //attack = true;
    }

    public void layerDown() {
        transform.position += new Vector3(0, 0, 5);
        //collider.enabled = false;
        //attack = false;
    }

    public void Attacked(float damage) {
        anim.SetTrigger("isAttacked");
        if(hp > 0) hp -= damage;
    }
}
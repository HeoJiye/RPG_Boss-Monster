using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;


public class Mino_Hp : MonoBehaviour
{
	public float hp_max;

	public GameObject hp_bar;
	Slider slider;

	public GameObject[] reward;

	Animator anim;

	float hp;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        slider = hp_bar.GetComponent<Slider>();

        hp = hp_max;
    }

    void Update()
    {
		slider.value = hp / hp_max;
		if (slider.value <= 0)
			hp_bar.SetActive(false);

        if(hp <= 0) {
            anim.SetBool("isDie", true);
        }
	}

    public void Die() {
        int num = Random.Range(0, reward.Length);
        Instantiate(reward[num], new Vector3(0f, 0f, 0f), Quaternion.identity);
        Destroy(gameObject);
    }

    public void Attacked(float damage) {
    	hp -= damage;
        anim.SetTrigger("isAttacked");
    }
}

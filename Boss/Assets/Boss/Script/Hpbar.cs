using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Hpbar : MonoBehaviour
{
	Slider hp_bar;

	public float hp_max;

    // Start is called before the first frame update
    void Start()
    {
        hp_bar = GetComponent<Slider>();
		hp_max = 100f;
    }

    // Update is called once per frame
    void Update()
    {
		hp_bar.value = Minotaur.hp / hp_max;
		if (hp_bar.value <= 0)
			transform.Find("Fill Area").gameObject.SetActive(false);
	}
}

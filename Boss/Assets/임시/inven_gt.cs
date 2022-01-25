using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inven_gt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //플레이어와 필드 아이템 충돌시
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("FieldItem") && Input.GetKeyDown(KeyCode.Z))
        {
            GameObject item = collision.gameObject;
            Destroy(item);
        }
    }
}

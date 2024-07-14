using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    public float speed = 5f; // 이동 속도
    public float damage = 10f;
    public Transform firespawn;
    public GameObject fire;
    void Update()
    {
        if (!gameObject.GetComponent<SpriteRenderer>().flipX)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        else
            transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            collision.gameObject.GetComponent<HpHandler>().SetHp(damage);
            
        
            Destroy(gameObject);
            Instantiate(fire, firespawn.position, Quaternion.identity);
        }
    }
}

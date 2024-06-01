using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HpHandler : MonoBehaviour
{
    public Slider slider;
    public float maxHp = 200f;
    private float currentHp;

    //³Ë¹é
    public float KnockbackTime = 0.2f;
    private float currentKnockbackTime = 0;
    public float pushForce = 100f;
    private Rigidbody2D rb;
    public GameObject KnockBackObject;

    private void Update()
    {
        if (currentKnockbackTime > 0)
        {
            currentKnockbackTime -= Time.deltaTime;
            KnockBack();
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHp = maxHp;
        slider.value = currentHp / maxHp;
    }
    
    public void SetHp(float damage) 
    {
        currentHp -= damage;
        slider.value = currentHp / maxHp;
        currentKnockbackTime = KnockbackTime;
    }
    private void KnockBack()
    {
        Vector2 pushDirection = -KnockBackObject.transform.forward * pushForce;
        rb.AddForce(pushDirection, ForceMode2D.Impulse);

    }
}

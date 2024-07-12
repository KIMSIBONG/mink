using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class HpHandler : MonoBehaviour
{
    public Slider slider;
    public float maxHp = 200f;
    private float currentHp;
    public bool knockback = false;

    //³Ë¹é
    public float KnockbackTime = 0.2f;
    [SerializeField] private float currentKnockbackTime = 0;
    public float speed = 100f;
    float currentSpeed;
    private Rigidbody2D rb;

    private void Update()
    {
        if (currentKnockbackTime > 0 && knockback == true)
        {
            currentSpeed = speed / (KnockbackTime - currentKnockbackTime + 0.1f);
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
        if(GetComponent<PlayerAttack>().player1)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    

        else
        {
            Vector2 pushDirection = Vector2.right;
            transform.Translate(Vector3.right * currentSpeed * Time.deltaTime);
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Unity.VisualScripting.Member;
using static UnityEditor.Experimental.GraphView.GraphView;

public class HpHandler : MonoBehaviour
{
    public Slider slider;
    public float maxHp = 200f;
    private float currentHp;
    public bool knockback = false;
    private Animator animator;
    public float force1 = 1f;
    private float hurttime;
    private float endGame;
    public BoxCollider2D p1c;
    
    //넉백
    public float KnockbackTime = 0.2f;
    [SerializeField] private float currentKnockbackTime = 0;
    public float speed = 100f;
    float currentSpeed;
    private Rigidbody2D rb;
    //문제는 가드를 맞고난 후에 해도 날라가는것 고치는법 1 
    //1.
   
    private void Update()
    {
        if (currentKnockbackTime > 0 && knockback == true && GetComponent<PlayerAttack>().guard1 == true)
        {
            currentSpeed = speed / (KnockbackTime - currentKnockbackTime + 0.1f);
            currentKnockbackTime -= Time.deltaTime;
            
            KnockBack();
            
            
        }
        if (currentHp <= 0)
        {
            endGame += Time.deltaTime;
            animator.SetBool("die",true);

            if (p1c != null)
            {
                BoxCollider2D collider = p1c.GetComponent<BoxCollider2D>();
                if (collider != null)
                {
                    collider.enabled = false;
                }
            }


        }
        if (endGame > 3)
        {
            SceneManager.LoadScene("end");
        }
    }

    private void Start()
    {
        p1c = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentHp = maxHp;
        slider.value = currentHp / maxHp;

        
    }
    
    public void SetHp(float damage) 
    {
        
        animator.SetTrigger("hurt");
        currentHp -= damage;
        slider.value = currentHp / maxHp;
        currentKnockbackTime = KnockbackTime;
        
    }
    
    private void KnockBack()
    {
        if(GetComponent<PlayerAttack>().player1)
        {
            rb.AddForce(Vector2.left * force1, ForceMode2D.Impulse);
        }
    

        else
        {
            Vector2 pushDirection = Vector2.right;
            rb.AddForce(Vector2.right * force1, ForceMode2D.Impulse);
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PlayerAttack : MonoBehaviour
{
    public bool player1 = true;
    public float damage = 5f;
    private float timeSinceAttack;
    private int m_currentAttack = 0;
    public bool Canmove = true;
    public bool guard1 = false;
    public bool guard2 = false;
    private Animator animator;
    private HpHandler knocktry;


    

    [SerializeField] private Transform attackPos;
    [SerializeField] private Vector2 boxSize;
    private void Start()
    {
        animator = GetComponent<Animator>();
        knocktry = GetComponent<HpHandler>();
    }
    void Update()
    {
        timeSinceAttack += Time.deltaTime;

        if (player1 && Input.GetKeyDown(KeyCode.J) && timeSinceAttack > 0.35f)
        {
            
            Attack();

            Canmove = false;
        }
        else if (!player1 && Input.GetKeyDown(KeyCode.Keypad1) && timeSinceAttack > 0.35f)
        {
            
            Attack();
            Canmove = false;
            
        }
        //가드(미완성
        if (Input.GetKeyDown(KeyCode.G))
        {

            guard1 = true;
            Debug.Log("가");
        }
        if (Input.GetKeyUp(KeyCode.G))
        {
            guard1 = false;
            Debug.Log("풀");
        }

        if (timeSinceAttack > 0.35f)
        {
            Canmove = true;
        }
        
        if (guard1 == true)
        {
            knocktry.knockback = true;
            damage = 1f;
            Canmove = false;
        }
        if (guard1 == false)
        {
            knocktry.knockback = false;
            damage = 5f;
            Canmove = true;
        }
        //스킬
        if (player1 && Input.GetKeyDown(KeyCode.Z) && timeSinceAttack > 0.35f)
        {
            animator.SetTrigger("flykick");
            
            
        }
    }

    private void Attack()
    {
        
        m_currentAttack++;
        damage += 3.0f;
        //1타
        animator.SetTrigger("attack");



        if (m_currentAttack > 3)
        {
            damage = 5.0f;
            m_currentAttack = 1;
        }


        if (timeSinceAttack > 1.0f)
        {
            damage = 5.0f;
            m_currentAttack = 1;
        }

        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(attackPos.position, boxSize, 0);
        foreach (Collider2D collider in collider2Ds)
        {
            if (collider.tag == "Player" && collider.gameObject != gameObject)
            {
                collider.GetComponent<HpHandler>().SetHp(damage);

            }
        }
        
        timeSinceAttack = 0.0f;
        
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(attackPos.position, boxSize);
    }
    
    

}

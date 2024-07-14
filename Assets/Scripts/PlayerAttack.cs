using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PlayerAttack : MonoBehaviour
{
    public bool player1 = true;
    public float damage = 10f;
    private float timeSinceAttack;
    
    public float dashspeed = 5f; // 이동 속도
    public float AttackDashDistance = 3f;
    public bool Canmove = true;
    public bool guard1 = false;
    public bool guard2 = false;
    public float force = 50f;
    public GameObject dasheffect;
    public Transform dashspawn;
    private Animator animator;
    private HpHandler knocktry;


    private float Zskillcool1 = 1f;
    private float Zskillcool2 = 1f;
    private float attackcool = 1f;
    private float attackcool1 = 1f;
    private Rigidbody2D rb;



    [SerializeField] private Transform attackPos;
    [SerializeField] private Vector2 boxSize;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        knocktry = GetComponent<HpHandler>();
    }
    void Update()
    {
        timeSinceAttack += Time.deltaTime;
        attackcool -= Time.deltaTime;
        attackcool1 -= Time.deltaTime;
        Zskillcool1 -= Time.deltaTime;
        Zskillcool2 -= Time.deltaTime;
        if (player1 && Input.GetKeyDown(KeyCode.X) && timeSinceAttack > 0.35f && attackcool<=0f)
        {
            
            Attack();
            attackcool = 1f;
            Canmove = false;
        }
        else if (!player1 && Input.GetKeyDown(KeyCode.Keypad1) && timeSinceAttack > 0.35f && attackcool1 <= 0f)
        {

            Attack();
            Canmove = false;
            attackcool1 = 1f;
        }
        //가드
        if (player1 && Input.GetKeyDown(KeyCode.G))
        {
            
            guard1 = true;
            animator.SetBool("guard", true);
            Debug.Log("가드");
            

        }
        
        if (player1 && Input.GetKeyUp(KeyCode.G))
        {
            guard1 = false;
            Debug.Log("가드풀림");
            animator.SetBool("guard", false);
        }
        
        if (!player1 && Input.GetKeyDown(KeyCode.Keypad0))
        {
            
            guard1 = true;
            animator.SetBool("guard", true);
            Debug.Log("가드");
            

        }
        if (!player1 && Input.GetKeyUp(KeyCode.Keypad0))
        {
            guard1 = false;
            animator.SetBool("guard", false);
            Debug.Log("가드풀림");
        }
        
        //가드(미완성
        

        if (timeSinceAttack > 0.35f)
        {
            Canmove = true;
        }
        if (guard1 == true)
        {
            knocktry.knockback = true;
            Canmove = false;
            damage = 1f;
        }
        
        
        if (guard1 == false)
        {
            knocktry.knockback = false;
            damage = 10f;
            Canmove = true;
            
        }
        //스킬
        if (player1 && Input.GetKeyDown(KeyCode.Z) && timeSinceAttack > 0.35f && Zskillcool1 <= 0f)
        {
            animator.SetTrigger("flykick");
            Skill();
            Zskillcool1 = 1f;

        }
        if (!player1 && Input.GetKeyDown(KeyCode.Keypad3) && timeSinceAttack > 0.35f && Zskillcool2 <= 0f)
        {
            animator.SetTrigger("flykick");
            Skill();
            Zskillcool2 = 1f;

        }
    }

    private void Attack()
    {

        Instantiate(dasheffect, dashspawn.position, Quaternion.identity);
        
        
        


        //1타
        animator.SetTrigger("strike");



        

        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(attackPos.position, boxSize, 0);
        foreach (Collider2D collider in collider2Ds)
        {
            if (collider.tag == "Player" && collider.gameObject != gameObject)
            {
                collider.GetComponent<HpHandler>().SetHp(damage);
                
            }
        }
        

        // 실제 이동 적용
        
        
        
        


    }
    private void Skill()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(attackPos.position, boxSize, 0);
        foreach (Collider2D collider in collider2Ds)
        {
            if (collider.tag == "Player" && collider.gameObject != gameObject)
            {
                collider.GetComponent<HpHandler>().SetHp(damage);
                
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(attackPos.position, boxSize);
    }
    
    

}

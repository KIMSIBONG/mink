using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PlayerAttack : MonoBehaviour
{
    public bool player1 = true;
    public float damage = 5f;
    private float timeSinceAttack;
    
    public float dashspeed = 5f; // 이동 속도
    public float AttackDashDistance = 3f;
    public bool Canmove = true;
    public bool guard1 = false;
    public bool guard2 = false;
   
    public GameObject dasheffect;
    public Transform dashspawn;
    private Animator animator;
    private HpHandler knocktry;
    private float DashBreaktime = 0f;
    



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
            Skill();


        }
    }

    private void Attack()
    {

        Instantiate(dasheffect, dashspawn.position, Quaternion.identity);
        DashBreaktime++;
        
        


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
        if (DashBreaktime < 0.35)
        {
            transform.Translate(Vector3.right * dashspeed * Time.deltaTime);
        }
        if (DashBreaktime > 0.35)
        {
            Destroy(dasheffect);
        }
        
        


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

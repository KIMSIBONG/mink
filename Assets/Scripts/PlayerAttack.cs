using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PlayerAttack : MonoBehaviour
{
    public bool player1 = true;
    public float damage = 10f;
    private float timeSinceAttack;
    private int m_currentAttack = 0;
    [SerializeField] private Transform attackPos;
    [SerializeField] private Vector2 boxSize;

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
        }
        //가드(미완성
        if (Input.GetKeyDown(KeyCode.G))
        {
            Guard();
            Debug.Log("가");
        }
        if (Input.GetKeyUp(KeyCode.G))
        {
            damage = 10f;
            Debug.Log("풀");
        }
    }

    private void Attack()
    {
        m_currentAttack++;
        damage += 2.0f;

        if (m_currentAttack > 3)
        {
            damage = 10.0f;
            m_currentAttack = 1;
        }


        if (timeSinceAttack > 1.0f)
        {
            damage = 10.0f;
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
    private void Guard()
    {
        damage = 0f;
    }
    

}

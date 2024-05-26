using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PlayerAttack : MonoBehaviour
{
    public float damage = 10f;
    private float timeSinceAttack;
    private int m_currentAttack = 0;
    [SerializeField] private Transform attackPos;
    [SerializeField] private Vector2 boxSize;

    void Update()
    {
        timeSinceAttack += Time.deltaTime;

        if (Input.GetKeyDown("j") && timeSinceAttack > 0.35f)
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
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(attackPos.position, boxSize);
    }

}

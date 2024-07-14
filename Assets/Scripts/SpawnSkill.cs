using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class SpawnSkill : MonoBehaviour
{
    public GameObject prefabToSpawn;  
    public Transform spawnLocation;
    private Animator animator;
    private float skillcool1 = 2f;
    private float skillcool2 = 2f;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        skillcool1 -= Time.deltaTime;
        skillcool2 -= Time.deltaTime;
        if (gameObject.GetComponent<PlayerAttack>().player1 && Input.GetKeyDown(KeyCode.F)&& skillcool1 <= 0f)
        {

            animator.SetTrigger("attack");
            SpawnPrefab();
            skillcool1 = 2f;

        }

        if (!gameObject.GetComponent<PlayerAttack>().player1 && Input.GetKeyDown(KeyCode.Keypad2) && skillcool2 <= 0f)
        {

            animator.SetTrigger("attack");
            SpawnPrefab();
            skillcool2 = 2f;

        }

    }
    
    private void SpawnPrefab()
    {
        
        if (gameObject.GetComponent<PlayerAttack>().player1)
            Instantiate(prefabToSpawn, spawnLocation.position, Quaternion.identity);
            
        else
        {
            Instantiate(prefabToSpawn, spawnLocation.position, Quaternion.identity).GetComponent<SpriteRenderer>().flipX = true;
        }
    }
    
    
}
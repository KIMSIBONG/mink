using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class SpawnSkill : MonoBehaviour
{
    public GameObject prefabToSpawn;  
    public Transform spawnLocation;
    private Animator animator;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (gameObject.GetComponent<PlayerAttack>().player1 && Input.GetKeyDown(KeyCode.F))
        {

            animator.SetTrigger("attack");
            SpawnPrefab();
            
            
        }

        if (!gameObject.GetComponent<PlayerAttack>().player1 && Input.GetKeyDown(KeyCode.Keypad2))
        {

            animator.SetTrigger("attack");
            SpawnPrefab();
            

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
using UnityEngine;

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
        if (Input.GetKeyDown(KeyCode.F))
        {
            SpawnPrefab();
        }
        
    }
    
    private void SpawnPrefab()
    {
        animator.SetTrigger("attack");
        if (gameObject.GetComponent<PlayerAttack>().player1)
            Instantiate(prefabToSpawn, spawnLocation.position, Quaternion.identity);
        else
        {
            Instantiate(prefabToSpawn, spawnLocation.position, Quaternion.identity).GetComponent<SpriteRenderer>().flipX = true;
        }
    }
    
    
}
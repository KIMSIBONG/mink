using UnityEngine;

public class SpawnSkill : MonoBehaviour
{
    public GameObject prefabToSpawn1;  
    public Transform spawnLocation1;

    public GameObject prefabToSpawn2;
    public Transform spawnLocation2;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SpawnPrefab();
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            SpawnPrefab2();
        }
    }
    
    private void SpawnPrefab()
    {
        if (gameObject.GetComponent<PlayerAttack>().player1)
            Instantiate(prefabToSpawn1, spawnLocation1.position, Quaternion.identity);
        
    }
    
    private void SpawnPrefab2()
    {
        if (!gameObject.GetComponent<PlayerAttack>().player1)
        {
            Instantiate(prefabToSpawn2, spawnLocation2.position, Quaternion.identity).GetComponent<SpriteRenderer>().flipX = true;
        }
                
        
            
    }
}
using UnityEngine;

public class SpawnSkill : MonoBehaviour
{
    public GameObject prefabToSpawn;  
    public Transform spawnLocation; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SpawnPrefab();
        }
    }
    
    private void SpawnPrefab()
    {
        if (gameObject.GetComponent<PlayerAttack>().player1)
            Instantiate(prefabToSpawn, spawnLocation.position, Quaternion.identity);
        else
            Instantiate(prefabToSpawn, spawnLocation.position, Quaternion.identity).GetComponent<SpriteRenderer>().flipX = true;
    }
}
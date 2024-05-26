using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Sprite spriteToSpawn;  // 소환할 스프라이트 이미지
    public Transform spawnLocation;  // 스프라이트가 소환될 위치

    void Update()
    {
        // 'F' 키를 눌렀을 때 스프라이트 소환
        if (Input.GetKeyDown(KeyCode.F))
        {
            SpawnSprite();
        }
    }

    void SpawnSprite()
    {
        // 새로운 게임 오브젝트 생성
        GameObject newSpriteObject = new GameObject("SpawnedSprite");

        // SpriteRenderer 컴포넌트를 추가하고 스프라이트 설정
        SpriteRenderer spriteRenderer = newSpriteObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteToSpawn;

        // 소환 위치 설정
        newSpriteObject.transform.position = spawnLocation.position;
    }
}
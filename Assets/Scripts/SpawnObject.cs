using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Sprite spriteToSpawn;  // ��ȯ�� ��������Ʈ �̹���
    public Transform spawnLocation;  // ��������Ʈ�� ��ȯ�� ��ġ

    void Update()
    {
        // 'F' Ű�� ������ �� ��������Ʈ ��ȯ
        if (Input.GetKeyDown(KeyCode.F))
        {
            SpawnSprite();
        }
    }

    void SpawnSprite()
    {
        // ���ο� ���� ������Ʈ ����
        GameObject newSpriteObject = new GameObject("SpawnedSprite");

        // SpriteRenderer ������Ʈ�� �߰��ϰ� ��������Ʈ ����
        SpriteRenderer spriteRenderer = newSpriteObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteToSpawn;

        // ��ȯ ��ġ ����
        newSpriteObject.transform.position = spawnLocation.position;
    }
}
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player1;
    public Transform player2;

    public float minDistanceX = 5f; // �÷��̾� ������ �ּ� X �Ÿ�
    public float fixedY = 0f; // ������ Y ��
    public float zoomSpeed = 2f; // �� �ӵ�
    public float offset = 10f;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        // �÷��̾� ������ X �Ÿ� ���
        float distanceX = Mathf.Abs(player1.position.x - player2.position.x);

        // X �Ÿ��� �ּ� X �Ÿ� �� �� ū ���� �����Ͽ� ���� �Ÿ��� ���
        float targetDistanceX = Mathf.Max(distanceX, minDistanceX);

        // ī�޶��� ��ġ ���
        float middlePointX = (player1.position.x + player2.position.x) / 2f;

        // ī�޶��� ��ġ�� �߰� �������� �̵� (Y ���� ����)
        transform.position = new Vector3(middlePointX, fixedY, transform.position.z);

        // ī�޶��� ũ�� ����
        float targetZoom = (targetDistanceX + offset) / 2f / cam.aspect;
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * zoomSpeed);
    }
}

using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player1;
    public Transform player2;

    public float minDistanceX = 10f; // �÷��̾� ������ �ּ� X �Ÿ�
    
    public float zoomSpeed = 3f; // �� �ӵ�
    public float offset = 7f;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        float distanceX = Mathf.Abs(player1.position.x - player2.position.x);

        // X �Ÿ��� �ּ� X �Ÿ� �� �� ū ���� �����Ͽ� ���� �Ÿ��� ���
        float targetDistanceX = Mathf.Max(distanceX, minDistanceX);

        // ī�޶��� ��ġ ���
        float middlePointX = (player1.position.x + player2.position.x) / 2f;
        float middlePointY = (player1.position.y + player2.position.y) / 2f; // �÷��̾� �߰� ������ Y �� ���

        // ī�޶��� ��ġ�� �߰� �������� �̵�
        transform.position = new Vector3(middlePointX, middlePointY, transform.position.z);

        // ī�޶��� ũ�� ����
        float targetZoom = (targetDistanceX + offset) / 2f / cam.aspect;
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * zoomSpeed);
    }
}


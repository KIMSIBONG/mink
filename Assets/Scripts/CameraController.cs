using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player1;
    public Transform player2;

    public float minDistanceX = 10f; // 플레이어 사이의 최소 X 거리
    
    public float zoomSpeed = 3f; // 줌 속도
    public float offset = 7f;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        float distanceX = Mathf.Abs(player1.position.x - player2.position.x);

        // X 거리와 최소 X 거리 중 더 큰 값을 선택하여 최종 거리로 사용
        float targetDistanceX = Mathf.Max(distanceX, minDistanceX);

        // 카메라의 위치 계산
        float middlePointX = (player1.position.x + player2.position.x) / 2f;
        float middlePointY = (player1.position.y + player2.position.y) / 2f; // 플레이어 중간 지점의 Y 값 계산

        // 카메라의 위치를 중간 지점으로 이동
        transform.position = new Vector3(middlePointX, middlePointY, transform.position.z);

        // 카메라의 크기 조절
        float targetZoom = (targetDistanceX + offset) / 2f / cam.aspect;
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * zoomSpeed);
    }
}


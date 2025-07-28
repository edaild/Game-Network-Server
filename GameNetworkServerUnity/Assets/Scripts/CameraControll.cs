using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    [Header("타겟 (플레이어)")]
    [SerializeField] private Transform target;

    [Header("카메라 회전")]
    public float mouseSensitivity = 3.0f;
    public float minYAngle = -20f;
    public float maxYAngle = 60f;

    [Header("카메라 거리")]
    public float distance = 5.0f;
    public float zoomSpeed = 2f;
    public float minDistance = 2f;
    public float maxDistance = 10f;

    public CharacterControll characterControll;

    private float currentX = 0f;
    private float currentY = 20f;

    private bool istrueAltkey;


    private void Start()
    {
        characterControll = FindAnyObjectByType<CharacterControll>();
    }

    private void Update()
    {
        istrueAltkey = Input.GetKey(KeyCode.LeftAlt);
    }

    private void LateUpdate()
    {
        if (!target) return;

        if (!istrueAltkey)
        {
            currentX += Input.GetAxis("Mouse X") * mouseSensitivity;
            currentY -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            currentY = Mathf.Clamp(currentY, minYAngle, maxYAngle);


            // 마우스 휠로 줌 인/아웃
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            distance -= scroll * zoomSpeed;
            distance = Mathf.Clamp(distance, minDistance, maxDistance);

            // 카메라 위치 및 회전 계산
            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
            Vector3 offset = rotation * new Vector3(0, 0, -distance);
            transform.position = target.position + offset;
            transform.LookAt(target.position);
        }
        else
        {
            Debug.Log("키보드 ALT 키로 마우스 사용ㄴ");

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }


}



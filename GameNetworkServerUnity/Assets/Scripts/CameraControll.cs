using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    [Header("Ÿ�� (�÷��̾�)")]
    [SerializeField] private Transform target;

    [Header("ī�޶� ȸ��")]
    public float mouseSensitivity = 3.0f;
    public float minYAngle = -20f;
    public float maxYAngle = 60f;

    [Header("ī�޶� �Ÿ�")]
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


            // ���콺 �ٷ� �� ��/�ƿ�
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            distance -= scroll * zoomSpeed;
            distance = Mathf.Clamp(distance, minDistance, maxDistance);

            // ī�޶� ��ġ �� ȸ�� ���
            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
            Vector3 offset = rotation * new Vector3(0, 0, -distance);
            transform.position = target.position + offset;
            transform.LookAt(target.position);
        }
        else
        {
            Debug.Log("Ű���� ALT Ű�� ���콺 ��뤤");

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }


}



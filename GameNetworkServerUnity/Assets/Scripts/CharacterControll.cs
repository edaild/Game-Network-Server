using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterControll : MonoBehaviour
{
    [SerializeField] private PlayerSO playerSO;
    [SerializeField] private Transform cameratransform;

    private bool falsemove;


    void Start()
    {
        if (!playerSO)playerSO = GetComponent<PlayerSO>();
        playerSO.playerRigidbody = GetComponent<Rigidbody>();
        playerSO.playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
       falsemove = Input.GetKey(KeyCode.LeftAlt);

        if (!falsemove)
        {
            Move();
            Debug.Log("ĳ���� �̵��� ���� �Ǿ����ϴ�..");
        }
        else
        {
            Debug.Log("ĳ���� �̵��� �����ϴ�.");
            playerSO.playerAnimator.SetBool("isWark", false);
            playerSO.playerAnimator.SetBool("isRun", false);
        }
    }

    private void Move()
    {
        float playerHorizontalInput = Input.GetAxis("Horizontal");
        float playerVerticalInput = Input.GetAxis("Vertical");

        // ī�޶� ���� ����
        Vector3 camForward = cameratransform.forward;
        Vector3 camRight = cameratransform.right;

        // ���� �̵��� ���
        camForward.y = 0;
        camRight.y = 0;

        camForward.Normalize();
        camRight.Normalize();


        Vector3 direction = (camForward * playerVerticalInput + camRight * playerHorizontalInput).normalized;

        bool isInput = direction != Vector3.zero;
        bool isRunning = isInput && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift));

        if (direction != Vector3.zero)
        {
            Quaternion playerRotate = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, playerRotate, playerSO.PlayerRotateSpeed * Time.deltaTime);
        }



        float speed = isRunning ? playerSO.playerRunSpeed : playerSO.playerWarkSpeed;
        Vector3 move = direction * speed * Time.deltaTime;
        transform.position += move;

        playerSO.playerAnimator.SetBool("isWark", isInput && !isRunning);
        playerSO.playerAnimator.SetBool("isRun", isRunning);
    }

    void bike()
    {
        playerSO.playerAnimator.SetBool("ReedBike", true);
    }
}

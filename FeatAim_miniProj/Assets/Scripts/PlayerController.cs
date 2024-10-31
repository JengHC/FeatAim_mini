using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //public float WalkingSpeed = 7;
    //InputAction moveAction;
    CharacterController characterController;

    //public float mouseSens = 0.2f;
    float horizontalAngle;
    InputAction lookAction;

    [SerializeField]
    Transform cameraTransform;

    [SerializeField]
    float mouseSens = 0.2f;

    float verticalAngle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //��Ʈ ������ Ż�� ����
        Cursor.visible = false;

        InputActionAsset inputActions = GetComponent<PlayerInput>().actions;

        //moveAction = inputActions.FindAction("Move");
        lookAction = inputActions.FindAction("Look");

        characterController = GetComponent<CharacterController>();

        horizontalAngle = transform.localEulerAngles.y;
        verticalAngle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ////Move
        //Vector2 moveVector = moveAction.ReadValue<Vector2>();
        //Vector3 move = new Vector3(moveVector.x, 0, moveVector.y);

        //if (move.magnitude > 1)
        //{
        //    move.Normalize();
        //}
        //move = move * WalkingSpeed * Time.deltaTime;
        //move = transform.TransformDirection(move); //���� �Ĵٺ��� �ִ� ���⺤�ͷ� �ٲ��ش�
        //characterController.Move(move);

        // ���콺
        transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X")*mouseSens);

        verticalAngle -= Input.GetAxisRaw("Mouse Y") * mouseSens;
        verticalAngle = Mathf.Clamp(verticalAngle, -90f, 90f);
        cameraTransform.localEulerAngles = new Vector3(verticalAngle, 0, 0);




        ////���콺 �¿�
        //Vector2 look = lookAction.ReadValue<Vector2>();

        //float turnPlayer = look.x * mouseSens;
        //horizontalAngle += turnPlayer;
        //if (horizontalAngle >= 360) horizontalAngle -= 360;
        //if (horizontalAngle < 0) horizontalAngle += 360;

        //Vector3 currentAngle = transform.localEulerAngles;
        //currentAngle.y = horizontalAngle;
        //transform.localEulerAngles = currentAngle;

        //// ���콺 ����
        //float turnCam = look.y * mouseSens;
        //// ���콺�� ���� �ø��� ������� �����µ� ���� �÷��ٺ����� ������ �־�����ϱ� ������ -
        //verticalAngle -= turnCam;
        //verticalAngle = Mathf.Clamp(verticalAngle, -90f, 90f);
        //currentAngle = cameraTransform.localEulerAngles;
        //currentAngle.x = verticalAngle;
        //cameraTransform.localEulerAngles = currentAngle;
    }
}
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;

    float horizontalAngle;
    InputAction lookAction;

    [SerializeField]
    Transform cameraTransform;

    [SerializeField]
    float mouseSens = 0.2f;

    [SerializeField]
    LayerMask targetLayerMask;

    float verticalAngle;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        horizontalAngle = transform.localEulerAngles.y;
        verticalAngle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer.GameEnded)
        {
            return;
        }

        // ¸¶¿ì½º
        transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X")*mouseSens);

        verticalAngle -= Input.GetAxisRaw("Mouse Y") * mouseSens;
        verticalAngle = Mathf.Clamp(verticalAngle, -90f, 90f);
        cameraTransform.localEulerAngles = new Vector3(verticalAngle, 0, 0);
    }
}
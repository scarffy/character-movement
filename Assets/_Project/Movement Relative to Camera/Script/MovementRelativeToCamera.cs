using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRelativeToCamera : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] CharacterController _characterController;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = gameObject.AddComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayerRelativeToCamera();
    }

    void MovePlayerRelativeToCamera()
    {
        float playerVerticalInput = Input.GetAxis("Vertical");
        float playerHorizontalInput = Input.GetAxis("Horizontal");

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        forward.y = 0;
        right.y = 0;

        forward = forward.normalized;
        right = right.normalized;

        Vector3 forwardRelativeVerticalInput = playerVerticalInput * forward * _movementSpeed * Time.deltaTime;
        Vector3 rightRelativeVerticalInput = playerHorizontalInput * right * _movementSpeed * Time.deltaTime;

        Vector3 cameraRelativeMovement = forwardRelativeVerticalInput + rightRelativeVerticalInput;

        //! Maybe can use rigidbody instead since we need to have some collision over here
        //transform.Translate(cameraRelativeMovement);
        _characterController.Move(cameraRelativeMovement);
    }
}

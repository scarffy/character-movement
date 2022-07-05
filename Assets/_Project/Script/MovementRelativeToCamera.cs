using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRelativeToCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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

        Vector3 forwardRelativeVerticalInput = playerVerticalInput * forward * Time.deltaTime;
        Vector3 rightRelativeVerticalInput = playerHorizontalInput * right *Time.deltaTime;

        Vector3 cameraRelativeMovement = forwardRelativeVerticalInput + rightRelativeVerticalInput;

        //! Maybe can use rigidbody instead since we need to have some collision over here
        transform.Translate(cameraRelativeMovement);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Brackey
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionReference movementControl;

    public CharacterController controller;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;

    public Transform cam;

    private void OnEnable()
    {
        movementControl.action.Enable();
    }

    private void OnDisable()
    {
        movementControl.action.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = movementControl.action.ReadValue<Vector2>();
        Vector3 movementInput = new Vector3(movement.x, 0, movement.y);

        if(movementInput.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(movementInput.x, movementInput.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            //controller.Move(movementInput * speed * Time.deltaTime);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

            // Brackeys
            //float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            //float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            //transform.rotation = Quaternion.Euler(0f, angle, 0f);



            //Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            //controller.Move(moveDir.normalized * speed * Time.deltaTime);

        }

    }
}

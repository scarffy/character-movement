using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float _mouseSensitivity = 3f;

    private float _rotationY;
    private float _rotationX;

    [SerializeField] private Transform _target;

    [SerializeField] private float _distanceFromTarget = 3.0f;

    private Vector3 _currentRotation;
    private Vector3 _smoothVelocity = Vector3.zero;

    [SerializeField] private float _smoothTime = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity;

        _rotationY += mouseX;
        _rotationX += mouseY;

        _rotationX = Mathf.Clamp(_rotationX, -40, 40);

        Vector3 nextRotation = new Vector3(_rotationX, _rotationY);
        _currentRotation = Vector3.SmoothDamp(_currentRotation, nextRotation,ref _smoothVelocity,_smoothTime);

        transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);

        transform.position = _target.position - transform.forward * _distanceFromTarget;
    }
}

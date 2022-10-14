using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private MovementCharacteristics _characteristics;

    private float _vertical;

    private readonly string STR_VERTICAL = "Vertical";

    private const float DISTANSE_CAMERA_OFFSET = 5f;

    private CharacterController _controller;

    private Vector3 _direction;
    private Quaternion _look;

    private Vector3 TargetRotate => _camera.forward * DISTANSE_CAMERA_OFFSET;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();

        Cursor.visible = _characteristics.VisibleCursor;
    }

    // Update is called once per frame
    void Update()
    {   
        //Jump();
        Movement();
        Rotate();
    }

    private void Movement()
    {

        if (_controller.isGrounded)
        {
            _vertical = Input.GetAxis(STR_VERTICAL);

            _direction = transform.TransformDirection(_vertical, 0f, 0f).normalized;
        }

        _direction.y -= _characteristics.Gravity * Time.deltaTime;

        Vector3 dir = _direction * _characteristics.MovementSpeed * Time.deltaTime;

        _controller.Move(dir);

    }

    private void Rotate()
    {
        Vector3 target = TargetRotate;
        target.y = 0;

        _look = Quaternion.LookRotation(target);

        float speed = _characteristics.AngularSpeed * Time.deltaTime;
        
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _look, speed);
    }

    private void Jump()
    {
        Vector3 jumpDir = Vector3.zero;

        if (Input.GetKey(KeyCode.Space) && _controller.isGrounded)
        {
            jumpDir = new Vector3(0f, _characteristics.JumpSpeed, 0f) * Time.deltaTime;
        }

        _controller.Move(jumpDir);
    }
}

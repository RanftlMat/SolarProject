using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public int RotationSpeed;

    public CameraInput Input;

    private const float InternalMoveTargetSpeed = 8;
    private const float InternalMoveSpeed = 4;
    
    private bool _rightMouseDown;

    private Vector2 _mouseDelta;

    private Vector3 _cameraPositionTarget;
    private Vector3 _moveTarget;
    private Vector3 _moveDirection;

    private Camera _camera;

    void Start()
    {
        _camera = GetComponentInChildren<Camera>();

        _cameraPositionTarget = transform.position;
        _camera.transform.position = _cameraPositionTarget;
        _moveTarget = _cameraPositionTarget;

        Input = new CameraInput();
        Input.Enable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 value = context.ReadValue<Vector2>();
        
        _moveDirection = new Vector3(value.x, 0, value.y);
    }

    public void OnRotateToggle(InputAction.CallbackContext context)
    {
        _rightMouseDown = context.ReadValue<float>() > 0;
    }

    public void OnRotate(InputAction.CallbackContext context)
    {
        _mouseDelta = _rightMouseDown ? context.ReadValue<Vector2>() : Vector2.zero;
    }
    
    private void FixedUpdate()
    {
        _moveTarget += (transform.forward * _moveDirection.z + transform.right * 
            _moveDirection.x) * Time.fixedDeltaTime * InternalMoveTargetSpeed;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _moveTarget, Time.deltaTime * InternalMoveSpeed);

        transform.rotation *= Quaternion.AngleAxis(_mouseDelta.y * Time.deltaTime * RotationSpeed, Vector3.left);

        transform.rotation = Quaternion.Euler(
            transform.eulerAngles.x, 
            transform.eulerAngles.y + _mouseDelta.x * Time.deltaTime * RotationSpeed,
            transform.eulerAngles.z);
    }

    private void OnDestroy()
    {
        Input.Disable();
    }
}

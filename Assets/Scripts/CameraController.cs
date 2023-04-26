using UnityEngine;

public class CameraController : MonoBehaviour
{
    //SerializeField
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float pitch = 2f;
    [SerializeField] private float yawSpeed = 100f;
    //private 
    private float _currentZoom = 10;
    private float _zoomSpeed = 10f;
    private float _minZoom = 3f;
    private float _maxZoom = 10;
    private float _currentYaw = 0f;

    private void Update()
    {
        ZoomCamera();
        RotateCamera();
    }
    private void LateUpdate()
    {
        FollowPlayer();
        transform.RotateAround(target.position, Vector3.up, _currentYaw);
    }
    private void RotateCamera()
    {
        _currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }
    private void ZoomCamera()
    {
        _currentZoom -= Input.GetAxis("Mouse ScrollWheel") * _zoomSpeed;
        _currentZoom = Mathf.Clamp( _currentZoom, _minZoom, _maxZoom );
    }
    private void FollowPlayer()
    {
        transform.position = target.position - offset * _currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);
    }
}


using DG.Tweening;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _sensitivityRotation;
    [SerializeField] private float _sensitivityZoom;
    [SerializeField] private float _zoomMax;
    [SerializeField] private float _zoomMin;
    [SerializeField] private float _limitY;

    private void Awake()
    {
        transform.position = _target.position + _offset;
    }

    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            _offset.z += _sensitivityZoom;
        }
        
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            _offset.z -= _sensitivityZoom;
        }
        
        _offset.z = Mathf.Clamp(_offset.z, -Mathf.Abs(_zoomMax), -Mathf.Abs(_zoomMin));

        var X = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * _sensitivityRotation;
        var Y = Input.GetAxis("Mouse Y") * _sensitivityRotation;
        Y = Mathf.Clamp (Y, -_limitY, _limitY);
        transform.localEulerAngles = new Vector3(-Y, X, 0);
        transform.position = transform.localRotation * _offset + _target.position;
        
    }
}

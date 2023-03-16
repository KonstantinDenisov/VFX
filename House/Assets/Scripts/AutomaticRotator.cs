using DG.Tweening;
using UnityEngine;

public class AutomaticRotator : MonoBehaviour
{
    [SerializeField] private float _speedRotation;
    [SerializeField] private float _timeCycle;
    [SerializeField] private Transform _transform;
    private Vector3 _vector3;

    private void Start()
    {
        _vector3 = new Vector3(0, _speedRotation * Time.deltaTime * -1, 0);
        _transform.DORotate(_vector3, _timeCycle , RotateMode.WorldAxisAdd).SetLoops(100, LoopType.Yoyo);
    }
}

using DG.Tweening;
using UnityEngine;

public class AutomaticRotator : MonoBehaviour
{
    [SerializeField] private float _speedRotation;
    [SerializeField] private float _timeCycle;
    [SerializeField] private Transform _transform;
    private Vector3 _vector3;

    public void StartDOTween()
    {
        _vector3 = new Vector3(0, _speedRotation, 0);
        _transform.DORotate(_vector3, _timeCycle , RotateMode.LocalAxisAdd).SetLoops (-1, LoopType.Restart);
    }

    public void StopDOTween()
    {
        _transform.DOKill();
    }
    
}

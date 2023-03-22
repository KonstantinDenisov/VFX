using DG.Tweening;
using UnityEngine;

public class AutomaticRotator : MonoBehaviour
{
    [SerializeField] private float _speedRotation;
    [SerializeField] private float _timeCycle;
    [SerializeField] private Transform _transform;

    public void StartDOTween()
    {
        _transform.DORotate(new Vector3(0, _speedRotation, 0), _timeCycle , RotateMode.LocalAxisAdd)
            .SetLoops (-1, LoopType.Restart);
    }

    public void StopDOTween()
    {
        _transform.DOKill();
    }
}
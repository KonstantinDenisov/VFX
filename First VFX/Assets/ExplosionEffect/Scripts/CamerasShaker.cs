using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class CamerasShaker : MonoBehaviour
{
    [SerializeField] private List<Camera> _cameras;
    
    private static Vector3 _startPosition;

    private static Tween _lastShake;

    public Tween Shake(float duration, float strength, int vibrato, bool fadeOut = true)
    {
        if (_lastShake == null || !_lastShake.IsPlaying())
            _startPosition = _cameras.First().transform.position;

        _cameras.ForEach(shakeCamera =>
        {
            _lastShake = shakeCamera.transform.DOShakePosition(duration, strength, vibrato, 90F, false, fadeOut)
                .SetEase(Ease.Linear)
                .OnComplete(() => shakeCamera.transform.position = _startPosition);
        });

        return _lastShake;
    }
}

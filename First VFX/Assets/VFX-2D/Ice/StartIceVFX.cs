using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace VFX_2D.Ice
{
    public class StartIceVFX : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private ParticleSystem _boom;
        [SerializeField] private Button _button;
        [SerializeField] private SpriteRenderer _rocketSpriteRenderer;
        [SerializeField] private SpriteRenderer _bellSpriteRenderer;
        [SerializeField] private Transform _controlPoint1;
        [SerializeField] private Transform _controlPoint2;
        [SerializeField] private Transform _controlPoint3;
        [SerializeField] private Transform _controlPoint4;
        [SerializeField] private Transform _controlPoint5;
        [SerializeField] private Transform _controlPoint6;
        [SerializeField] private Transform _controlPoint7;
        [SerializeField] private Transform _controlPoint8;
        [SerializeField] private Transform _controlPoint9;
        [SerializeField] private Vector3 _rotate;
        [SerializeField] private float _scale;
        [SerializeField] private float _durationScale;
        [SerializeField] private float _durationRotate;
        [SerializeField] private Vector3 [] _pathWaypoints;
        [SerializeField] private float _duration;


        private void Start()
        {
            _button.onClick.AddListener(PlayerVFX);
            
            _pathWaypoints = new[]
            {
                _controlPoint1.position, _controlPoint2.position, _controlPoint3.position
                , _controlPoint4.position, _controlPoint5.position, _controlPoint6.position
                , _controlPoint7.position, _controlPoint8.position, _controlPoint9.position
            };
            
        }

        private void PlayerVFX()
        {
            DOTween.Sequence()
                .Append(_rocketSpriteRenderer.transform.DOPath(_pathWaypoints, _duration, PathType.CubicBezier)
                    .SetLookAt(Vector3.down)
                    .SetEase(Ease.InQuart)
                    .OnStart(_particleSystem.Play)
                    .OnComplete(_boom.Play))
                .Append(_bellSpriteRenderer.transform.DOScale(Vector3.zero, 0.25f))
                .Join(_bellSpriteRenderer.transform.DOScale(Vector3.one * _scale, _durationRotate))
                    .SetLoops(3, LoopType.Yoyo)
                .Join(_bellSpriteRenderer.transform.DORotate(_rotate, _durationRotate))
                .Append(_bellSpriteRenderer.transform.DORotate(-_rotate, _durationRotate))
                .Append(_bellSpriteRenderer.transform.DORotate(_rotate, _durationRotate))
                .Append(_bellSpriteRenderer.transform.DORotate(-_rotate, _durationRotate));
        }
    }
}

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
        private Vector3 _startPosition;
        private Vector3 _scaleBell;


        private void Start()
        {
            _button.onClick.AddListener(PlayerVFX);

            _startPosition = _rocketSpriteRenderer.transform.position;
            _scaleBell = _bellSpriteRenderer.transform.localScale;
            
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
                    .SetLookAt(0, Vector3.right, Vector3.forward)
                    .SetEase(Ease.InQuart)
                    .OnStart(_particleSystem.Play)
                    .OnComplete(_boom.Play))
                .AppendCallback(() =>
                {
                    _particleSystem.Clear();
                    _particleSystem.Stop();
                })
                .Append(_rocketSpriteRenderer.transform.DOScale(Vector3.zero, 0.25f))
                .Join(_bellSpriteRenderer.transform.DOScale(new Vector3(1 * _scale * 2, 1, 1), _durationScale * 2))
                .Join(_bellSpriteRenderer.transform.DORotate(_rotate * 3, _durationRotate * 2))
                    .SetEase(Ease.OutQuad)
                .Append(_bellSpriteRenderer.transform.DOScale(new Vector3(0.5f, 1 * _scale * 1.5f, 1), _durationScale * 3))
                .Join(_bellSpriteRenderer.transform.DORotate(-_rotate * 2, _durationRotate * 3))
                    .SetEase(Ease.InFlash)
                .Append(_bellSpriteRenderer.transform.DOScale(Vector3.one * _scale, _durationScale * 4))
                .Join(_bellSpriteRenderer.transform.DORotate(_rotate, _durationRotate * 4))
                    .SetEase(Ease.InElastic)
                .Append(_bellSpriteRenderer.transform.DOScale(_scaleBell, _durationScale * 5))
                .Join(_bellSpriteRenderer.transform.DORotate(Vector3.one, _durationRotate * 5))
                    .SetEase(Ease.InQuart)
                .AppendCallback(() =>
                {
                    _rocketSpriteRenderer.transform.position = _startPosition;
                    _rocketSpriteRenderer.transform.DOScale(Vector3.one * 0.4f, 0f);
                    _rocketSpriteRenderer.transform.DORotate(Vector3.zero, 0f);
                });
        }
    }
}

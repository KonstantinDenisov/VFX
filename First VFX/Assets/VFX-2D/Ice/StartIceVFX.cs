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
        private Quaternion _startRotation;
        private Vector3 _scaleBell;


        private void Start()
        {
            _button.onClick.AddListener(PlayerVFX);

            _startPosition = _rocketSpriteRenderer.transform.position;
            var transform1 = _bellSpriteRenderer.transform;
            _scaleBell = transform1.localScale;
            _startRotation = transform1.rotation;
            
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
                .AppendCallback(() =>
                {
                    _rocketSpriteRenderer.transform.position = _startPosition;
                    _rocketSpriteRenderer.transform.DOScale(Vector3.one * 0.4f, 0f);
                    _rocketSpriteRenderer.transform.DORotate(Vector3.zero, 0f);
                })
                .Append(_rocketSpriteRenderer.transform.DOPath(_pathWaypoints, _duration, PathType.CubicBezier)
                    .SetLookAt(0, Vector3.right, Vector3.forward)
                    .SetEase(Ease.InOutQuad)
                    .OnStart(_particleSystem.Play)
                    .OnComplete(() =>
                    {
                        _rocketSpriteRenderer.transform.DOScale(Vector3.zero, 0.25f);
                        _boom.Play();
                        _particleSystem.Stop();
                        
                        BellAnimation();
                    }));
        }

        private void BellAnimation()
        {
            DOTween.Sequence()
                .AppendInterval(0.2f)
                .Append(_bellSpriteRenderer.transform.DOScale(new Vector3(1.2f, 0.8f, 1), _durationScale * 2)
                    .SetEase(Ease.InOutQuad))
                .Join(_bellSpriteRenderer.transform.DORotate(Vector3.zero + new Vector3(0, 0, -25), 0.17f)
                    .SetEase(Ease.OutQuad))
                .Append(_bellSpriteRenderer.transform.DOScale(new Vector3(0.9f, 1.1f, 1),
                        0.26f)
                    .SetEase(Ease.OutQuad))
                .Join(_bellSpriteRenderer.transform.DORotate(Vector3.zero + new Vector3(0, 0, 25), 0.23f)
                    .SetEase(Ease.InOutQuad))
                .Append(_bellSpriteRenderer.transform.DOScale(Vector3.one * 0.5f, 0.26f).SetEase(Ease.OutBack))
                .Join(_bellSpriteRenderer.transform.DORotate(Vector3.zero, 0.24f).SetEase(Ease.OutBack));
        }
    }
}

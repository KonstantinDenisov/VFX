using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace VFX_2D.Ice
{
    public class StartIceVFX : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;
        
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

            _rocketSpriteRenderer.transform.DOPath(_pathWaypoints, _duration, PathType.CubicBezier);

            /*
            _particleSystem.Stop();
            _particleSystem.Clear();
            
            _rocketSpriteRenderer.DOFade(0f, 0f);
            _rocketSpriteRenderer.transform.localScale = Vector3.one * 1.5f;

            DOTween.Sequence()
                .AppendCallback(_particleSystem.Play)
                .Append(_rocketSpriteRenderer.DOFade(1f, _appearanceTime).SetEase(Ease.InSine))
                .Join(_rocketSpriteRenderer.transform.DOScale(Vector3.one * 2, 0.6f).SetEase(Ease.OutBack))
                .SetDelay(0.4f);
                */
        }
    }
}

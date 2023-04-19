using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace VFX_2D.Ice
{
    public class StartIceVFX : MonoBehaviour
    {
        [SerializeField] private float _appearanceTime = 0.7f;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Transform _transform;
        [SerializeField] private Button _button;
        [SerializeField] private ParticleSystem _particleSystem;

        private void Start()
        {
            _button.onClick.AddListener(PlayerVFX);
        }

        private void PlayerVFX()
        {
            _particleSystem.Stop();
            _particleSystem.Clear();
            
            _spriteRenderer.DOFade(0f, 0f);
            _spriteRenderer.transform.localScale = Vector3.one * 1.5f;

            DOTween.Sequence()
                .AppendCallback(_particleSystem.Play)
                .Append(_spriteRenderer.DOFade(1f, _appearanceTime).SetEase(Ease.InSine))
                .Join(_spriteRenderer.transform.DOScale(Vector3.one * 2, 0.6f).SetEase(Ease.OutBack))
                .SetDelay(0.4f);
        }
    }
}

using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace VFX_2D.Ice
{
    public class StartIceVFX : MonoBehaviour
    {
        [SerializeField] private float _appearanceTime = 1f;
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
            _spriteRenderer.DOFade(1, _appearanceTime);
            _particleSystem.Play();
        }
    }
}

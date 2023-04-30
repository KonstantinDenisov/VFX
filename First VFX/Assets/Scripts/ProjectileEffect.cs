using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ProjectileEffect : MonoBehaviour
{
    [SerializeField] private Button _play;
    [SerializeField] private Animator _animatorPlayer;
    [SerializeField] private Animator _animatorEnemy;
    [SerializeField] private ParticleSystem _spell;
    [SerializeField] private ParticleSystem _energize;
    [SerializeField] private ParticleSystem _boom;
    [SerializeField] private Transform _finish;
    [SerializeField] private float _time;
    [SerializeField] private float _delay;
    private Vector3 _startPosition;

    private void Awake()
    {
        _play.onClick.AddListener(PlayAnimation);
        _startPosition = _spell.transform.position; 
    }

    private void PlayAnimation()
    {
        _spell.transform.DOMove(_startPosition, 0);
        _spell.Play();
        _energize.Play();
        _animatorPlayer.SetTrigger("Spell");
        
        _spell.transform.DOMove(_finish.position, _time)
            .OnComplete(() =>
            {
                _animatorEnemy.SetTrigger("Spell"); 
                _boom.Play();
            })
            .SetEase(Ease.InSine)
            .SetDelay(_delay);
    }
}

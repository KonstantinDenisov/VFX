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
    [SerializeField] private Transform _finish;
    [SerializeField] private float _time;
    [SerializeField] private float _delay;
    private Vector3 _startPosition;

    private void Awake()
    {
        _play.onClick.AddListener(PlayAnimation);
        _spell.transform.position = _startPosition;
    }

    private void PlayAnimation()
    {
        _spell.transform.DOMove(_finish.position, _time)
            .OnStart(() =>
            {
                _spell.Play();
                _animatorPlayer.SetTrigger("Spell");
            })
            .OnComplete(() =>
            {
                _animatorEnemy.SetTrigger("Spell"); 
            })
            .SetDelay(_delay);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlashesEffects : MonoBehaviour
{
    [SerializeField] private Button _play;
    [SerializeField] private ParticleSystem _spell;
    [SerializeField] private ParticleSystem _claw;
    [SerializeField] private Animator _animator;
    [SerializeField] private Animator _animatorClaw;
    
    private void Awake()
    {
        _play.onClick.AddListener(Play);
    }

    private void Play()
    {
        _animator.SetTrigger("Spell");
        _animatorClaw.SetTrigger("Spell"); 
        _spell.Play();
        _claw.Play();
    }
}

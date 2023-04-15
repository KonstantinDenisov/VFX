using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button _play;
    [SerializeField] private Animator _animator;
    [SerializeField] private ParticleSystem _spell;
    [SerializeField] private ParticleSystem _rightHand;
    [SerializeField] private ParticleSystem _leftHand;
    
    private void Awake()
    {
        _play.onClick.AddListener(PlayAnimation);
    }

    private void PlayAnimation()
    {
        _animator.SetTrigger("Spell");
        _spell.Play();
        _rightHand.Play();
        _leftHand.Play();
    }
}

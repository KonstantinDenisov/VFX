using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button _play;
    [SerializeField] private Animator _animator;
    [SerializeField] private ParticleSystem _spell;
    
    private void Awake()
    {
        _play.onClick.AddListener(PlayAnimation);
    }

    private void PlayAnimation()
    {
        _animator.SetTrigger("Spell");
        _spell.Play();
    }
}

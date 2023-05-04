using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayBoom : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private float _magnitude;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _delay;
    
    
    [SerializeField] private Button _play;
    [SerializeField] private ParticleSystem _spell;

    [Header("New")]
    [SerializeField] private CamerasShaker _camerasShaker;
    [SerializeField] private float _shakeDelay;
    [SerializeField] private float _shakeDuration;
    [SerializeField] private float _shakeStrength;
    [SerializeField] private int _shakeVibrato;

    private void Awake()
    {
        _play.onClick.AddListener(PlayExplosionEffect);
    }

    private void PlayExplosionEffect()
    {
        _spell.Play();
        Shake(_camerasShaker);
       // StartCoroutine(Shake(_duration, _magnitude));
    }

    private void Shake(CamerasShaker shaker)
    {
        shaker.Shake(_shakeDuration, _shakeStrength, _shakeVibrato).SetDelay(_shakeDelay);
    }
    
    
    
    /*
    public IEnumerator Shake (float duration, float magnitude)
    {
        yield return new WaitForSeconds(_delay);
        Vector3 originalPos = _camera.transform.position;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            _camera.transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        _camera.transform.localPosition = originalPos;

    }
    */
}

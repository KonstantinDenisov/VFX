using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayBoom : MonoBehaviour
{
    [SerializeField] private Button _play;
    [SerializeField] private ParticleSystem _spell;
    [SerializeField] private float _duration;
    [SerializeField] private float _magnitude;
    [SerializeField] private Camera _camera;

    private void Awake()
    {
        _play.onClick.AddListener(PlayExplosionEffect);
    }

    private void PlayExplosionEffect()
    {
        // _spell.Play();
        StartCoroutine(Shake(_duration, _magnitude));
    }
    
    public IEnumerator Shake (float duration, float magnitude)
    {
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
}

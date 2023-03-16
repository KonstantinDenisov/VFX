using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _automaticRotator;
    [SerializeField] private GameObject _manuallyRotator;
    
    [Header("Buttons")]
    [SerializeField] private Button _buttonAutomatic;
    [SerializeField] private Button _buttonManually;

    private void Awake()
    {
        _buttonAutomatic.onClick.AddListener(AutomaticModeActive);
        _buttonManually.onClick.AddListener(ManuallyModeActive);
    }

    private void ManuallyModeActive()
    {
        _automaticRotator.SetActive(false);
        _manuallyRotator.SetActive(true);
    }

    private void AutomaticModeActive()
    {
        _automaticRotator.SetActive(true);
        _manuallyRotator.SetActive(false);
    }
}

using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private AutomaticRotator _automaticRotator;
    [SerializeField] private ManuallyRotator _manuallyRotator;
    
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
        
    }

    private void AutomaticModeActive()
    {
        
    }
}

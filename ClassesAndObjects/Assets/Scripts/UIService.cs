using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIService : MonoBehaviour
{
    private List<Employee> _employers;

    [Header("Consoles")]
    [SerializeField] private TextMeshProUGUI _consoleCreateMenu;
    [SerializeField] private TextMeshProUGUI _consoleStartMenu;
    [SerializeField] private TextMeshProUGUI _consoleDeleteMenu;

    [Header("Menus")]
    [SerializeField] private GameObject _startMenu;
    [SerializeField] private GameObject _createMenu;
    [SerializeField] private GameObject _deleteMenu;

    [Header("InputField")]
    [SerializeField] private InputField _organization;
    [SerializeField] private InputField _salary;
    [SerializeField] private InputField _experience;
    [SerializeField] private InputField _deleteIndex;
    [SerializeField] private InputField _firstName;
    [SerializeField] private InputField _lastName;
    [SerializeField] private InputField _patronymic;
    [SerializeField] private InputField _dateOfBirth;

    [Header("Buttons")]
    [SerializeField] private Button _buttonEnterToCreateMenu;
    [SerializeField] private Button _enterToDeleteMenuButton;
    [SerializeField] private Button _writeInformationButton;
    [SerializeField] private Button _createEmployeeButton;
    [SerializeField] private Button _backToStartMenuCreateMenuButton;
    [SerializeField] private Button _deleteCurrentEmployeeButton;
    [SerializeField] private Button _deleteAllEmployeeButton;
    [SerializeField] private Button _backToStartMenuDeleteMenu;

    private void Awake()
    {
        _buttonEnterToCreateMenu.onClick.AddListener(EnterToCreateMenu);
        _enterToDeleteMenuButton.onClick.AddListener(EnterToDeleteMenu);
        _writeInformationButton.onClick.AddListener(WriteInformation);
        _createEmployeeButton.onClick.AddListener(CreateEmployeeButton);
        _backToStartMenuCreateMenuButton.onClick.AddListener(BackToStartMenuFromTheCreateMenu);
        _deleteCurrentEmployeeButton.onClick.AddListener(DeleteCurrentEmployee);
        _deleteAllEmployeeButton.onClick.AddListener(DeleteAllEmployee);
        _backToStartMenuDeleteMenu.onClick.AddListener(BackToStartMenuDeleteMenu);
    }

    private void Start()
    {
        _deleteMenu.SetActive(false);
        _createMenu.SetActive(false);
        _startMenu.SetActive(true);
        _employers = new List<Employee>();
    }

    private void BackToStartMenuDeleteMenu()
    {
        ClearDeleteConsole();
        _deleteMenu.SetActive(false);
        _startMenu.SetActive(true);
    }

    private void DeleteAllEmployee()
    {
        _employers.Clear();
        _consoleDeleteMenu.text = "List clear";
    }

    private void DeleteCurrentEmployee()
    {
        int index = Convert.ToInt32(_deleteIndex.text);
        index--;
        WriteDeleteInformation(_employers[index].GetFirstName());
        _employers.RemoveAt(index);
        ClearDeleteInputField();
    }

    private void BackToStartMenuFromTheCreateMenu()
    {
        ClearCreateConsole();
        _createMenu.SetActive(false);
        _startMenu.SetActive(true);
    }

    private void CreateEmployeeButton()
    {
        _employers.Add(new Employee(_organization.text, Convert.ToInt32(_salary.text),
            Convert.ToInt32(_experience.text), _firstName.text, _lastName.text, _patronymic.text
            , Convert.ToInt32(_dateOfBirth.text)));
        WriteCreateInformation(_firstName.text);
        ClearCreateInputField();
    }

    private void WriteInformation()
    {
        if (_employers.Count == 0)
        {
            _consoleStartMenu.text = "List empty";
        }

        string information = null;

        foreach (var employee in _employers)
        {
            information += employee.Information();
        }

        _consoleStartMenu.text = information;
    }

    private void WriteDeleteInformation(string name)
    {
        _consoleDeleteMenu.text = $"Employee {name} was be deleted";
    }

    private void WriteCreateInformation(string name)
    {
        _consoleCreateMenu.text = $"Employee {name} was be created";
    }

    private void EnterToDeleteMenu()
    {
        ClearStartConsole();
        _startMenu.SetActive(false);
        _deleteMenu.SetActive(true);
    }

    private void EnterToCreateMenu()
    {
        ClearStartConsole();
        _startMenu.SetActive(false);
        _createMenu.SetActive(true);
    }

    private void ClearStartConsole()
    {
        _consoleStartMenu.text = "";
    }

    private void ClearDeleteConsole()
    {
        _consoleDeleteMenu.text = "";
    }

    private void ClearCreateConsole()
    {
        _consoleCreateMenu.text = "";
    }

    private void ClearCreateInputField()
    {
        _organization.text = "";
        _salary.text = "";
        _experience.text = "";
        _dateOfBirth.text = "";
        _patronymic.text = "";
        _lastName.text = "";
        _firstName.text = "";
    }

    private void ClearDeleteInputField()
    {
        _deleteIndex.text = "";
    }
    
    
}
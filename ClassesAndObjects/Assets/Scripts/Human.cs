using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human
{
    private string _firstName;
    private string _lastName;
    private string _patronymic;
    private int _dateOfBirth;
        

    public string GetFirstName()
    {
        return _firstName;
    }

    public void SetFirstName(string firstName)
    {
        _firstName = firstName;
    }
    public string GetLastName()
    {
        return _lastName;
    }

    public void SetLastName(string lastName)
    {
        _lastName = lastName;
    }
        
    public string GetPatronymic()
    {
        return _patronymic;
    }

    public void SetPatronymic(string patronymic)
    {
        _patronymic = patronymic;
    }
        
    public int GetDateOfBirth()
    {
        return _dateOfBirth;
    }

    public void SetDateOfBirth(int dateOfBirth)
    {
        _dateOfBirth = dateOfBirth;
    }

    public virtual void PrintInformation()
    {
        Console.WriteLine($"First Name - {_firstName}, Last Name - {_lastName}, Patronymic - {_patronymic}," +
            $"Date of birth - {_dateOfBirth}");
    }
}

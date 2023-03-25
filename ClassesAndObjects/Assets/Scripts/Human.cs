using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Human
{
    protected string FirstName;
    protected string LastName;
    protected string Patronymic;
    protected int DateOfBirth;

    public string GetFirstName()
    {
        return FirstName;
    }

    public void SetFirstName(string firstName)
    {
        FirstName = firstName;
    }

    public string GetLastName()
    {
        return LastName;
    }

    public void SetLastName(string lastName)
    {
        LastName = lastName;
    }

    public string GetPatronymic()
    {
        return Patronymic;
    }

    public void SetPatronymic(string patronymic)
    {
        Patronymic = patronymic;
    }

    public int GetDateOfBirth()
    {
        return DateOfBirth;
    }

    public void SetDateOfBirth(int dateOfBirth)
    {
        DateOfBirth = dateOfBirth;
    }

    public virtual void PrintInformation()
    {
        Console.WriteLine($"First Name - {FirstName}, Last Name - {LastName}, Patronymic - {Patronymic}," +
            $"Date of birth - {DateOfBirth}");
    }

    public virtual string Information()
    {
        string info;
        info = ($"First Name - {FirstName}, Last Name - {LastName}, Patronymic - {Patronymic}," +
            $"Date of birth - {DateOfBirth}");
        return info;
    }
}
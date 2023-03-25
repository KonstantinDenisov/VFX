using System;

public class Employee : Human
{
    private string _organization;
    private int _salary;
    private int _experience;

    public string GetOrganization()
    {
        return _organization;
    }

    public void SetOrganization(string organization)
    {
        _organization = organization;
    }

    public int GetSalary()
    {
        return _salary;
    }

    public void SetSalary(int salary)
    {
        _salary = salary;
    }

    public int GetExperience()
    {
        return _experience;
    }

    public void SetExperience(int experience)
    {
        _experience = experience;
    }

    public Employee()
    {
        Console.WriteLine("was created Employee");
    }

    public Employee(string organization, int salary, int experience)
    {
        _organization = organization;
        _salary = salary;
        _experience = experience;

        Console.WriteLine("was created Employee");
    }

    public Employee(string organization, int salary, int experience, string firstName, string lastName
        , string patronymic, int dateOfBirth)
    {
        _organization = organization;
        _salary = salary;
        _experience = experience;
        FirstName = firstName;
        LastName = lastName;
        Patronymic = patronymic;
        DateOfBirth = dateOfBirth;
    }

    ~Employee()
    {
        Console.WriteLine("was destroyed Employee");
    }

    public override void PrintInformation()
    {
        base.PrintInformation();
        Console.WriteLine($"Organization - {_organization}, Salary - {_salary}, Experience - {_experience}");
    }

    public override string Information()
    {
        string inf;
        inf = base.Information();
        string information = $"{inf}, Organization - {_organization}, Salary - {_salary}, Experience - {_experience}";
        return information;
    }
}
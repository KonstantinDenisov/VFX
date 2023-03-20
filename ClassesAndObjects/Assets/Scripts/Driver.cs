using System;

public sealed class Driver : Employee
{
    private string _carBrand;
    private string _carModel;
        
    public string GetСarBrand()
    {
        return _carBrand;
    }

    public void SetCarBrand(string carBrand)
    {
        _carBrand = carBrand;
    }
        
    public string GetCarModel()
    {
        return _carModel;
    }

    public void SetCarModel(string carModel)
    {
        _carModel = carModel;
    }

    public Driver()
    {
        Console.WriteLine("was created Driver");
    }

    public Driver(string carBrand, string carModel)
    {
        _carBrand = carBrand;
        _carModel = carModel;
        Console.WriteLine("was created Driver");
    }

    ~Driver()
    {
        Console.WriteLine("was destroyed Driver");
    }
        
    public override void PrintInformation()
    {
        base.PrintInformation();
        Console.WriteLine($"Car Brand - {_carBrand}, Car Model - {_carModel}");
    }
}

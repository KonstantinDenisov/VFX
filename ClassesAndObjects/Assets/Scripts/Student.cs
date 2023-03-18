using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student : Human
{
    private string _faculty;
    private int _course;
    private int _group;
        
    public string GetFaculty()
    {
        return _faculty;
    }

    public void SetFaculty(string faculty)
    {
        _faculty = faculty;
    }
        
    public int GetCourse()
    {
        return _course;
    }

    public void SetCourse(int course)
    {
        _course = course;
    }
        
    public int GetGroup()
    {
        return _group;
    }

    public void SetGroup(int group)
    {
        _group = group;
    }

    public Student()
    {
        Console.WriteLine("was created Student");
    }
        
    public Student(string faculty, int course, int group)
    {
        _faculty = faculty;
        _course = course;
        _group = group;
            
        Console.WriteLine("was created Student");
    }
        
        
    ~Student()
    {
        Console.WriteLine("was destroyed Student");
    }

    public override void PrintInformation()
    {
        base.PrintInformation();
        Console.WriteLine($"Faculty - {_faculty}, Course - {_course}, Group - {_group}");
    }
}

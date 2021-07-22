using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProjectData", menuName = "Projects", order = 1)]
public class ProjectData : ScriptableObject
{
    public string Id { get; set; }
    public string _name { get; set; }
    public string _description { get; set; }
    public string Grade { get; set; }
    private List<Teacher> teachers;
    private List<Student> students;
    private List<string> evaluations;
    public string join_code { get; set; }
}


public class PlayerProfile : MonoBehaviour
{
    public string id { get; set; }
    public string mail { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public int rol { get; set; }
    public string org_id { get; set; }
}

public class Teacher : PlayerProfile
{

}

public class Student : PlayerProfile
{
    
}

[CreateAssetMenu]
public class FloatVariable : ScriptableObject
{
    public float Value;
}


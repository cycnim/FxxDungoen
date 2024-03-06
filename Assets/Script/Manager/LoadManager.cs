using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : MonoBehaviour
{
    public List<List<Dictionary<string, object>>> list = new List<List<Dictionary<string, object>>>();

    public static List<Dictionary<string, object>> SaveData_Char = new List<Dictionary<string, object>>();
    public static List<Dictionary<string, object>> Stat_Char = new List<Dictionary<string, object>>();
    public static List<Dictionary<string, object>> Coefficient_Char = new List<Dictionary<string, object>>();

    public static List<Dictionary<string, object>> SkillData= new List<Dictionary<string, object>>();


    private void Awake()
    {
        SaveData_Char = GetCSV("Data/CharData/SaveData_Char");
        Stat_Char = GetCSV("Data/CharData/Stat_Char");
        Coefficient_Char = GetCSV("Data/CharData/Coefficient_Char");

        SkillData = GetCSV("Data/SkillData/SkillData");
    }

    private void Start()
    {
        //GetCSV(ref SaveDat, "Data/CharData/SaveData_Char");
        foreach (var item in SaveData_Char)
        {
            Debug.Log(item["레벨"]);
        }
    }

    private void GetCSV(ref List<Dictionary<string, object>> keyValuePairs, string file)
    {
        keyValuePairs = CSVReader.Read(file);
    }

    public List<Dictionary<string, object>> GetCSV(string file)
    {
        return CSVReader.Read(file);
    }
}

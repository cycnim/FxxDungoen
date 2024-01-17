using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : MonoBehaviour
{
    public List<List<Dictionary<string, object>>> list = new List<List<Dictionary<string, object>>>();
    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }

    private void GetCSV(ref List<Dictionary<string, object>> keyValuePairs, string file)
    {
        keyValuePairs = CSVReader.Read(file);
    }
}

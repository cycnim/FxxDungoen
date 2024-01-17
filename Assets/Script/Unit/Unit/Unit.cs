using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField]private StatInfo statInfo;

    private void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1))
        {
            statInfo.SettingStat(1);
        }
    }
}

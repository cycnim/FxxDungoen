using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))//임시용 스탯뿌리기
        {
            //StatInfo.SettingStat_Char(1);
        }
        if (Input.GetKeyDown(KeyCode.Q))//임시용 공격
        {
            Debug.Log("플레이어가 공격 공격");
            SetDamage();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Unit
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) //임시용 스탯뿌리기
        {
            //StatInfo.SettingStat_Monster(1);
        }
        if (Input.GetKeyDown(KeyCode.W))//임시용 공격
        {
            Debug.Log("몬스터가 공격");
            SetDamage();
        }

    }

    /// <summary>
    /// 랜덤으로 플레이어를 타겟으로 잡음
    /// </summary>
    public void TargetTraking(Player player)
    {
        Target = player;
    }
}

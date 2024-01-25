using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleSystemManager : MonoBehaviour
{
    [SerializeField]private Player[] players = new Player[4];
    [SerializeField]private Monster[] monsters = new Monster[4];

    List<Unit> OrderedUnitsByAttack = new List<Unit>(); // 공격순서 유닛들 

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))//임시용 스탯뿌리기
        {
            DataSetting();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))//임시용 배틀 관련된 함수 호출
        {

        }
    }

    public void DataSetting()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].StatInfo.SettingStat_Char(i);
        }

        for (int i = 0; i < monsters.Length; i++)
        {
            monsters[i].StatInfo.SettingStat_Monster(i);
        }
        var unit = players.Cast<Unit>().Concat(monsters.Cast<Unit>()).ToList(); //유닛들 목록 들고오기 

        unit.ToList().ForEach(item => item.StatInfo.growthInfo.speed += Random.Range(1, 8)); // 각 유닛들의 스피드 값에 1~8값넣어서 순서


        foreach (var item in unit)
        {

        }
        

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DamageDeliverys;
using System;
using Random = UnityEngine.Random;
using System.Linq;

public class Unit : MonoBehaviour
{
    public enum Force
    {
        Player,
        Monster
    }

    [SerializeField] private StatInfo statInfo; //데이터
    [SerializeField] private Unit target;

    [SerializeField] protected Force forceType;
    private SkillInfo[] skillInfos;

    public Unit Target { get => target; set => target = value; }
    public StatInfo StatInfo { get => statInfo; set => statInfo = value; }
    public Force ForceType { get => forceType; set => forceType = value; }

    public int attackOrder;
    /// <summary>
    /// 공격함수
    /// </summary>
    protected void SetDamage()
    {
        target.statInfo.battleInfo.cur_Hp -= 
        DamageDelivery.NomalAttack
        (statInfo.battleInfo.physics_AattckPoint, 
        target.statInfo.battleInfo.physics_Defence , 0);
    }

    private void SkillInfoSetting()
    {
        
    }
    public void SkillIconUISetting(List<SkillIcon> skillIcon)
    {
        //skillIcon.ForEach((icon, index) => icon.SetSkillData(skillInfos[index]));
        Enumerable.Range(0, Mathf.Min(skillIcon.Count, skillInfos.Length))
        .ToList()
        .ForEach(i => skillIcon[i].SetSkillData(skillInfos[i]));


        //for (int i = 0; i < skillInfos.Length; i++)
        //{
        //    skillIcon[i].SetSkillData(skillInfos[i]);

        //}

    }


    // VS 


    //public static (int, int) LengthReturn(dynamic units)
    //{
    //    if (units is Unit[])
    //    {
    //        return (0, units.Length);
    //    }
    //    else if (units is List<Unit>)
    //    {
    //        return (0, units.Count);
    //    }
    //    else
    //    {
    //        throw new ArgumentException("올바른 유형의 인수가 전달되지 않았습니다.");
    //    }
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DamageDeliverys;


public class Unit : MonoBehaviour
{
    public enum Force
    {
        Player,
        Monster
    }

    protected Force force;
    [SerializeField] private StatInfo statInfo; //데이터
    [SerializeField] private Unit target;

    public Unit Target { get => target; set => target = value; }
    public StatInfo StatInfo { get => statInfo; set => statInfo = value; }
    public Force Force1 { get => force; set => force = value; }


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
}

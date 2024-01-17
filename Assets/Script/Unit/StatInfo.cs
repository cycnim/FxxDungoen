using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class StatInfo
{
    #region 각 인포들 정리
    [SerializeField] LevelInfo levelInfo;
    [SerializeField] BattleInfo battleInfo;
    [SerializeField] TurnInfo turnInfo;
    [SerializeField] HitInfo hitInfo;
    [SerializeField] GrowthInfo growthInfo;
    #endregion

    [System.Serializable]
    public struct LevelInfo
    {
        /// <summary>
        /// 레벨
        /// </summary>
        [SerializeField]private int level;
        /// <summary>
        /// 현재 경험치
        /// </summary>
        [SerializeField] private float cur_Exp;
        /// <summary>
        /// 렙업 필요경험치
        /// </summary>
        [SerializeField] private float max_Exp;
        /// <summary>
        /// 경험치 전달함수
        /// </summary>
        /// <param name="getExp"></param>
        public void GetExp(int getExp)
        {
            cur_Exp += getExp;
            if (cur_Exp >= max_Exp) //현재 경험치가 도달 경험치보다 많을 경우 레벨업
            {
                cur_Exp -= max_Exp;
                level += 1;
            }
        }
    }

    [Serializable]
    public struct BattleInfo
    {
        /// <summary>
        /// 현재 체력
        /// </summary>
        [SerializeField] private float cur_Hp;
        /// <summary>
        /// 최대 체력
        /// </summary>
        [SerializeField] private float max_Hp;
        /// <summary>
        /// 현재 마나
        /// </summary>
        [SerializeField] private int cur_mp;
        /// <summary>
                        /// 최대 마나
                        /// </summary>
        [SerializeField] private int max_mp;
        /// <summary>
        /// 체력 회복력
        /// </summary>
        [SerializeField] private float hpRegen;
        /// <summary>
        /// 마나 회복력
        /// </summary>
        [SerializeField] private float mpRegen;
        /// <summary>
        /// 물리 공격력
        /// </summary>
        [SerializeField] private float pAp;
        /// <summary>
        /// 마법 공격력
        /// </summary>
        [SerializeField] private float mAp;
        /// <summary>
        /// 물리방어력
        /// </summary>
        [SerializeField] private int pDef;
        /// <summary>
        /// 마법 방어력
        /// </summary>
        [SerializeField] private int mDef;
    }

    [Serializable]
    public struct TurnInfo
    {
        /// <summary>
        /// 현재 행동력
        /// </summary>
        [SerializeField] private int cur_Action;
        /// <summary>
        /// 최대 행동력
        /// </summary>
        [SerializeField] private int max_Action;
    }

    [Serializable]
    public struct HitInfo
    {
        /// <summary>
        /// 회피율
        /// </summary>
        [SerializeField] private int agi;
        /// <summary>
        /// 명중률
        /// </summary>
        [SerializeField] private int hit;
    }
    [Serializable]
    public struct GrowthInfo
    {
        /// <summary>
        /// 힘
        /// </summary>
        [SerializeField] private int strong;
        /// <summary>
        /// 지
        /// </summary>
        [SerializeField] private int magic;
        /// <summary>
        /// 행동력 차는 속도
        /// </summary>
        [SerializeField] private float speed;
        /// <summary>
        /// 민첩성
        /// </summary>
        [SerializeField] private float dex;
    }
}


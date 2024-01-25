using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class StatInfo
{
    public string unitName;// ㅇㄹ

    #region 각 인포들 정리
    public LevelInfo levelInfo;
    public BattleInfo battleInfo;
    public TurnInfo turnInfo;
    public HitInfo hitInfo;
    public GrowthInfo growthInfo;
    #endregion

    [Serializable]
    public struct LevelInfo 
    {
        /// <summary>
        /// 레벨
        /// </summary>
        public int level;
        /// <summary>
        /// 현재 경험치
        /// </summary>
        public int cur_Exp;
        /// <summary>
        /// 렙업 필요경험치
        /// </summary>
        public int max_Exp;


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
                LevelUp();
            }
        }
        public void LevelUp()
        {
            level += 1;
        }

        public void GetData(int lv, int exp)
        {
            level = lv;
            cur_Exp = exp;
        }
    }

    [Serializable]
    public struct BattleInfo
    {
        /// <summary>
        /// 현재 체력
        /// </summary>
        public int cur_Hp;
        /// <summary>
        /// 최대 체력
        /// </summary>
        public int max_Hp;
        /// <summary>
        /// 현재 마나
        /// </summary>
        public int cur_mp;
        /// <summary>
                        /// 최대 마나
                        /// </summary>
        public int max_mp;
        /// <summary>
        /// 체력 회복력
        /// </summary>
        public int hpRegen;
        /// <summary>
        /// 마나 회복력
        /// </summary>
        public int mpRegen;
        /// <summary>
        /// 물리 공격력
        /// </summary>
        public int physics_AattckPoint;
        /// <summary>
        /// 마법 공격력
        /// </summary>
        public int magic_AattckPoint;
        /// <summary>
        /// 물리방어력
        /// </summary>
        public int physics_Defence;
        /// <summary>
        /// 마법 방어력
        /// </summary>
        public int magic_Defence;
        /// <summary>
        /// 종합 방어력
        /// </summary>
        public int total_Defence;

        public void GetData(int hp, int mp, int hg, int mg, int pAp, int mAp, int pDef, int mDef,int tDef, int ch, int cm)
        {
            max_Hp = hp;
            max_mp = mp;
            hpRegen = hg;
            mpRegen = mg;
            physics_AattckPoint = pAp;
            magic_AattckPoint = mAp;
            physics_Defence = pDef;
            magic_Defence = mDef;
            total_Defence = tDef;
            cur_Hp = ch;
            cur_mp = cm;
        }
    }

    [Serializable]
    public struct TurnInfo
    {
        /// <summary>
        /// 현재 행동력
        /// </summary>
        public int cur_Action;
        /// <summary>
        /// 최대 행동력
        /// </summary>
        public int max_Action;

        public void GetData(int action)
        {
            max_Action = action;
        }
    }

    [Serializable]
    public struct HitInfo
    {
        /// <summary>
        /// 회피율
        /// </summary>
        public int agi;
        /// <summary>
        /// 명중률
        /// </summary>
        public int hit;
        public void GetData(int ag, int hi)
        {
            agi = ag;
            hit = hi;
        }
    }
    [Serializable]
    public struct GrowthInfo
    {
        /// <summary>
        /// 힘
        /// </summary>
        public int strong;
        /// <summary>
        /// 민첩성
        /// </summary>
        public float dex;
        /// <summary>
        /// 지
        /// </summary>
        public int magic;
        /// <summary>
        /// 행동력 차는 속도
        /// </summary>
        public float speed;

        public void GetData(int str, int mag, int dx, int spd)
        {
            strong = str;
            magic = mag;
            speed = spd;
            dex = dx;
        }
    }

    /*
     public void SettingStat(int i)
    {
        var SaveData_Char = CSVReader.Read("Data/CharData/SaveData_Char");
        var Coefficient_Char = CSVReader.Read("Data/CharData/Coefficient_Char");
        var Stat_Char = CSVReader.Read("Data/CharData/Stat_Char");

        int 레벨, 현재경험치, 체력, 마나, 체력회복, 마나회복, 공격력, 마력, 물방, 마방, 현재체력, 현재마나, 행동력, 회피, 명중, 힘, 민첩, 지능, 스피드;
        
        레벨 = Convert.ToInt32(SaveData_Char[i]["레벨"]);
        현재경험치 = Convert.ToInt32(SaveData_Char[i]["현재경험치"]);
        현재체력 = Convert.ToInt32(SaveData_Char[i]["현재체력"]);
        현재마나 = Convert.ToInt32(SaveData_Char[i]["현재마나"]);

        체력 = Convert.ToInt32(Stat_Char[i]["체력"]);
        마나 = Convert.ToInt32(Stat_Char[i]["마나"]);
        체력회복 = Convert.ToInt32(Stat_Char[i]["체력회복"]);
        마나회복 = Convert.ToInt32(Stat_Char[i]["마나회복"]);
        공격력 = Convert.ToInt32(Stat_Char[i]["공격력"]);
        마력 = Convert.ToInt32(Stat_Char[i]["마력"]);
        물방 = Convert.ToInt32(Stat_Char[i]["물방"]);
        마방 = Convert.ToInt32(Stat_Char[i]["마방"]);

        행동력 = Convert.ToInt32(Stat_Char[i]["행동력"]);
        회피 = Convert.ToInt32(Stat_Char[i]["회피"]); 
        명중 = Convert.ToInt32(Stat_Char[i]["명중"]);

        힘 = Convert.ToInt32(Stat_Char[i]["힘"]);
        민첩 = Convert.ToInt32(Stat_Char[i]["민첩"]); 
        지능 = Convert.ToInt32(Stat_Char[i]["지능"]);
        스피드 = Convert.ToInt32(Stat_Char[i]["스피드"]);

        int 힘계수, 민첩계수, 지능계수, 체력계수, 마나계수;
        힘계수 = Convert.ToInt32(Coefficient_Char[i]["힘계수"]);
        민첩계수 = Convert.ToInt32(Coefficient_Char[i]["민첩계수"]);
        지능계수 = Convert.ToInt32(Coefficient_Char[i]["지능계수"]);
        체력계수 = Convert.ToInt32(Coefficient_Char[i]["체력계수"]);
        마나계수 = Convert.ToInt32(Coefficient_Char[i]["마나계수"]);

        int 힘최종, 민첩최종, 지능최종, 체력최종, 마나최종;
        힘최종 = LvCol(레벨, 힘, 힘계수);
        민첩최종 = LvCol(레벨, 민첩, 민첩계수);
        지능최종 = LvCol(레벨, 지능, 지능계수);
        체력최종 = LvCol(레벨, 체력, 체력계수);
        마나최종 = LvCol(레벨, 마나, 마나계수);



        levelInfo.GetData(레벨,현재경험치);
        battleInfo.GetData(체력최종, 마나최종, 체력회복, 마나회복, 공격력, 마력, 물방, 마방, 현재체력, 현재마나);
        turnInfo.GetData(행동력);
        hitInfo.GetData(회피, 명중);
        growthInfo.GetData(힘최종, 민첩최종, 지능최종, 스피드);

        Debug.Log("포팅완료");
    }
     
     */


    /// <summary>
    /// 데이터 뿌려주는 함수
    /// </summary>
    /// <param name="i"></param>
    public void SettingStat_Char(int i)
    {
        i++;
        //시트 데이터 불러오기
        var SaveData_Char = CSVReader.Read("Data/CharData/SaveData_Char");
        var Coefficient_Char = CSVReader.Read("Data/CharData/Coefficient_Char");
        var Stat_Char = CSVReader.Read("Data/CharData/Stat_Char");

        //불러온 시트에 마춰 데이터 세팅
        unitName = Stat_Char[i]["이름"].ToString();
        //기본 스탯 데이터
        int level, currentExp, health, mana, healthRecovery, manaRecovery, attackPower, magicPower, physicalDefense, magicalDefense, totalDefence, currentHealth, currentMana, actionPoints, evasion, accuracy, strength, agility, intelligence, speed;
        

        level = Convert.ToInt32(SaveData_Char[i]["레벨"]);
        currentExp = Convert.ToInt32(SaveData_Char[i]["현재경험치"]);
        currentHealth = Convert.ToInt32(SaveData_Char[i]["현재체력"]);
        currentMana = Convert.ToInt32(SaveData_Char[i]["현재마나"]);

        
        health = Convert.ToInt32(Stat_Char[i]["체력"]);
        mana = Convert.ToInt32(Stat_Char[i]["마나"]);
        healthRecovery = Convert.ToInt32(Stat_Char[i]["체력회복"]);
        manaRecovery = Convert.ToInt32(Stat_Char[i]["마나회복"]);
        attackPower = Convert.ToInt32(Stat_Char[i]["공격력"]);
        magicPower = Convert.ToInt32(Stat_Char[i]["마력"]);
        physicalDefense = Convert.ToInt32(Stat_Char[i]["물방"]);
        magicalDefense = Convert.ToInt32(Stat_Char[i]["마방"]);
        totalDefence = Convert.ToInt32(Stat_Char[i]["종방"]);

        actionPoints = Convert.ToInt32(Stat_Char[i]["행동력"]);
        evasion = Convert.ToInt32(Stat_Char[i]["회피"]);
        accuracy = Convert.ToInt32(Stat_Char[i]["명중"]);

        strength = Convert.ToInt32(Stat_Char[i]["힘"]);
        agility = Convert.ToInt32(Stat_Char[i]["민첩"]);
        intelligence = Convert.ToInt32(Stat_Char[i]["지능"]);
        speed = Convert.ToInt32(Stat_Char[i]["스피드"]);
        

        //계수 데이터
        int strengthCoefficient, agilityCoefficient, intelligenceCoefficient, healthCoefficient, manaCoefficient;
        strengthCoefficient = Convert.ToInt32(Coefficient_Char[i]["힘계수"]);
        agilityCoefficient = Convert.ToInt32(Coefficient_Char[i]["민첩계수"]);
        intelligenceCoefficient = Convert.ToInt32(Coefficient_Char[i]["지능계수"]);
        healthCoefficient = Convert.ToInt32(Coefficient_Char[i]["체력계수"]);
        manaCoefficient = Convert.ToInt32(Coefficient_Char[i]["마나계수"]);

        //레벨에 따른 계수 세팅
        int finalStrength, finalAgility, finalIntelligence, finalHealth, finalMana;
        finalStrength = LvCol(level, strength, strengthCoefficient);
        finalAgility = LvCol(level, agility, agilityCoefficient);
        finalIntelligence = LvCol(level, intelligence, intelligenceCoefficient);
        finalHealth = LvCol(level, health, healthCoefficient);
        finalMana = LvCol(level, mana, manaCoefficient);

        //계산 및 정렬된 데이터 기반으로 데이터 삽입
        levelInfo.GetData(level, currentExp);
        battleInfo.GetData(finalHealth, finalMana, healthRecovery, manaRecovery, attackPower, magicPower, physicalDefense, magicalDefense, totalDefence, currentHealth, currentMana);
        turnInfo.GetData(actionPoints);
        hitInfo.GetData(evasion, accuracy);
        growthInfo.GetData(finalStrength, finalAgility, finalIntelligence, speed);

        Debug.Log("Porting completed");
    }

    /// <summary>
    /// 몬스터 전용 스탯 뿌려주기
    /// </summary>
    /// <param name="i"></param>
    public void SettingStat_Monster(int i)
    {
        //var SaveData_Char = CSVReader.Read("Data/MonsterData/Stat_Monster");
        //var Coefficient_Char = CSVReader.Read("Data/CharData/Coefficient_Char");
        i++;

        var Stat_Char = CSVReader.Read("Data/MonsterData/Stat_Monster");
        unitName = Stat_Char[i]["이름"].ToString();

        int   health, mana, healthRecovery, manaRecovery, attackPower, magicPower, physicalDefense, magicalDefense, totalDefence, actionPoints, evasion, accuracy, strength, agility, intelligence, speed;
        health = Convert.ToInt32(Stat_Char[i]["체력"]);
        mana = Convert.ToInt32(Stat_Char[i]["마나"]);
        healthRecovery = Convert.ToInt32(Stat_Char[i]["체력회복"]);
        manaRecovery = Convert.ToInt32(Stat_Char[i]["마나회복"]);
        attackPower = Convert.ToInt32(Stat_Char[i]["공격력"]);
        magicPower = Convert.ToInt32(Stat_Char[i]["마력"]);
        physicalDefense = Convert.ToInt32(Stat_Char[i]["물방"]);
        magicalDefense = Convert.ToInt32(Stat_Char[i]["마방"]);
        totalDefence = Convert.ToInt32(Stat_Char[i]["종방"]);

        actionPoints = Convert.ToInt32(Stat_Char[i]["행동력"]);
        evasion = Convert.ToInt32(Stat_Char[i]["회피"]);
        accuracy = Convert.ToInt32(Stat_Char[i]["명중"]);

        strength = Convert.ToInt32(Stat_Char[i]["힘"]);
        agility = Convert.ToInt32(Stat_Char[i]["민첩"]);
        intelligence = Convert.ToInt32(Stat_Char[i]["지능"]);
        speed = Convert.ToInt32(Stat_Char[i]["스피드"]);


        //계산 및 정렬된 데이터 기반으로 데이터 삽입
        battleInfo.GetData(health, mana, healthRecovery, manaRecovery, attackPower, magicPower, physicalDefense, magicalDefense, totalDefence, health, mana);
        turnInfo.GetData(actionPoints);
        hitInfo.GetData(evasion, accuracy);
        growthInfo.GetData(strength, agility, intelligence, speed);

    }

    /// <summary>
    /// 레벨에 비례 계수 세팅 계산 함수
    /// </summary>
    /// <param name="lv"></param>
    /// <param name="start"></param>
    /// <param name="Coef"></param>
    /// <returns></returns>
    private int LvCol(int lv, int start, int Coef)
    {
        return start + ((lv-1) * Coef);
    }
}


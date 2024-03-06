using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 테스용 스킬 정보 클래스
/// </summary>
[System.Serializable]
public class SkillInfo
{
    public Sprite image;
    public int cost;
    public string skillName;
    public int skillID;
    //SkillIcon.

    public SkillInfo(string type)
    {

    }

    /*
        MethodInfo methodInfo = typeof(SkillInfo).GetMethod("Skill_" + type.ToString(), BindingFlags.NonPublic | BindingFlags.Instance);
        if(methodInfo != null)
        {
            methodInfo.Invoke(this, null);
        }
     
     */

}

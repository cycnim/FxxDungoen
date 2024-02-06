using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillIcon : MonoBehaviour
{
    public Image image;
    public int cost;
    public string type;

    public void SetSkillData(SkillInfo skillInfo)
    {
        image = skillInfo.image;
        cost = skillInfo.cost;
        type = skillInfo.type;
    }
}

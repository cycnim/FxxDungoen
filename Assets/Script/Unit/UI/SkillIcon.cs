using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillIcon : MonoBehaviour
{
    public Image image;
    public TMP_Text text_skill;
    public TMP_Text text_cost; 

    public int cost;
    public string type;

    public void SetSkillData(SkillInfo skillInfo)
    {
        image.sprite = skillInfo.image;
        text_cost.text = "" + skillInfo.cost;
        text_skill.text = skillInfo.skillName;
        //type = skillInfo.type;
    }
}

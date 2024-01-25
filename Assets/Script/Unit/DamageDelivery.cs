using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DamageDeliverys
{
    /// <summary>
    /// 데미지 전달 관련 클래스
    /// </summary>
    public static class DamageDelivery
    {
        /// <summary>
        /// 공격력 - 방어력 = 값만 반환 해주는 함수 (임시)
        /// </summary>
        /// <param name="stat"></param>
        /// <param name="itemDamage"></param>
        /// <param name="armor"></param>
        /// <returns></returns>
        public static int NomalAttack(int damage, int armor, int trueDamage)
        {
            return (damage - armor) + trueDamage;
        }
        public static int SkillAttak()
        {
            return 0;
        }
    }
}


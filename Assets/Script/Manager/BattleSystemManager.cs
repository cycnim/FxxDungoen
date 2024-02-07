using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystemManager : MonoBehaviour
{
    [SerializeField]private Player[] players = new Player[4];
    [SerializeField]private Monster[] monsters = new Monster[4];

    public List<Unit> OrderedUnitsByAttack = new List<Unit>(); // 공격순서 유닛들 

    [SerializeField] private bool battlStart = false;

    //public Image 
    public List<SkillIcon> skillIcons = new List<SkillIcon>();
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))//임시용 스탯뿌리기
        {
            StartDataSetting();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))//임시용 공격
        {
            AttackStart();
        }
    }

    private void Start()
    {
        StartCoroutine(BattleLogic());
    }
    IEnumerator BattleLogic()
    {
        StartDataSetting();
        yield return null;
        
        int now = 0;
        while (now < OrderedUnitsByAttack.Count)
        {
            if (!battlStart)
            {
                Debug.Log("현재" + OrderedUnitsByAttack[now]);
                if (OrderedUnitsByAttack[now].ForceType == Unit.Force.Player) //플레이어
                {
                    battlStart = true;
                    //BattleChoice(OrderedUnitsByAttack[now]);
                    Debug.Log("루프 멈춰야됨");
                }
                else //몬스터
                {
                    (OrderedUnitsByAttack[now] as Monster).TargetTraking(TargetReturn(players));
                }
                now++;
            }
            yield return null;
        }
    }

    /// <summary>
    /// 임시로 만들어둔 랜덤으로 타겟 잡아주는
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="units"></param>
    /// <returns></returns>
    public T TargetReturn<T>(T[] units) where T : Unit
    {
        int point = 0;
        point = Random.Range(0, units.Length);
        return units[point];
    }

    private void BattleChoice<T>(T player) where T : Unit
    {
        player.SkillIconUISetting(skillIcons);
    }

    /// <summary>
    /// 처음 배틀 시작할때만 세팅해주는 함수
    /// </summary>
    public void StartDataSetting()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].StatInfo.SettingStat_Char(i);
        }

        for (int i = 0; i < monsters.Length; i++)
        {
            monsters[i].StatInfo.SettingStat_Monster(i);
        }

        var unit = players.Cast<Unit>().Concat(monsters.Cast<Unit>()).ToList(); //유닛들 합치기

        
        unit.ToList().ForEach(item => item.StatInfo.growthInfo.speed += Random.Range(1, 8)); // 각 유닛들의 스피드 값에 1~8값넣어서 순서
        OrderedUnitsByAttack = OrderedUnitsByAttack.OrderByDescending(item => item.ForceType).ToList(); //세력에 마춰서 2차 가공 정렬
        OrderedUnitsByAttack = unit.OrderByDescending(item => item.StatInfo.growthInfo.speed).ToList(); //스피드에 마춰서 정렬 

        //unit.  //저장된 데이터 스킬 뿌리기 (임시)


        //정렬코드 미완이고 나중에 만들땐 함수화 시켜서 반환 형식으로 해줘야됨
        int aa = -1;
        foreach (var item in OrderedUnitsByAttack)
        {
            item.attackOrder = aa;
            aa++;
            Debug.Log(aa + "번째 순서 스피드는 " + item.StatInfo.growthInfo.speed + "세력" + item.ForceType);
        }
        
        //int rand1 = Random.Range(1, 10);
        //int rand2 = Random.Range(1, 10);
        //(rand1, rand2) = GetNonDuplicateRandomPair();
        //Debug.Log("절때로 중복되면 안되는 값"+"A" + rand1 + "B" + rand2);
    }

    public void AttackStart()
    {
        
    }

    private void MonsterattackAI()
    {
        
    }


    public List<Unit> RandUnits(List<Unit> units)
    {
        List<Unit> tempUnits = new List<Unit>();
        System.Random random = new System.Random();

        foreach (var unit in units)
        {
            tempUnits.Add(unit);
        }
        for (int i = 0; i < tempUnits.Count - 1; i++) //중복 처리 
        {
            if (tempUnits[i].StatInfo.growthInfo.speed == tempUnits[i + 1].StatInfo.growthInfo.speed)
            {
                // 동일한 속도인 경우 랜덤하게 순서를 바꿈
                if (random.Next(2) == 0)
                {
                    Unit temp = tempUnits[i];
                    tempUnits[i] = tempUnits[i + 1];
                    tempUnits[i + 1] = temp;
                }
            }
        }

        var tPlayer = tempUnits.Where(a => a.ForceType == Unit.Force.Player);
        var tMonster = tempUnits.Where(a => a.ForceType == Unit.Force.Monster);
        List<Unit> tempUnits2 = new List<Unit>();
        foreach (var item in tempUnits)
        {
            foreach (var player in tPlayer)
            {
                if(item.StatInfo.growthInfo.speed == player.StatInfo.growthInfo.speed)
                {
                    tempUnits2.Add(player);
                }
                break;
            }
            foreach (var monster in tMonster)
            {
                if (item.StatInfo.growthInfo.speed == monster.StatInfo.growthInfo.speed)
                {
                    tempUnits2.Add(monster);
                }
                break;
            }
        }
        return tempUnits2;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="units"></param>
    /// <returns></returns>
    public List<Unit> RandUnits1(List<Unit> units) 
    {
        Unit temp = units[0];

        int oder = 0; 
        List<Unit> tempUnits = new List<Unit>(); //옮겨서 담아줄 리스트
        foreach (var next in units)
        {
            if(temp == next) 
            {
                //예외처리
                tempUnits.Add(temp);
            }
            else
            {
                if (temp.StatInfo.growthInfo.speed == next.StatInfo.growthInfo.speed) // 이전 아이템값과 speed 값이 같을때
                {
                    //랜덤 돌림
                    //int rand1, rand2;
                    (int rand1, int rand2) = GetNonDuplicateRandomPair();//랜덤 돌려줌 우선순위값

                    if(rand1 > rand2) //중복된 애들중 첫뻔째 애가 들어갈수있도록 다음깨 들어감
                    {
                        tempUnits.Remove(temp);
                        tempUnits.Add(next);
                    }
                    else // 중복된 애들중 두번째 애가 들어갈수 있도록
                    {
                        tempUnits.Add(temp);
                    }
                }  
            }

            next.attackOrder = oder;
            oder++;
        }
        Debug.Log("랜덤 우선순위값 재배치 완료");
        return units;
    }
    public List<Unit> RandUnits2(List<Unit> units)
    {
        List<Unit> tempUnits = new List<Unit>();
        System.Random random = new System.Random();

        foreach (var unit in units)
        {
            tempUnits.Add(unit);
        }

        for (int i = 0; i < tempUnits.Count - 1; i++)
        {
            if (tempUnits[i].StatInfo.growthInfo.speed == tempUnits[i + 1].StatInfo.growthInfo.speed)
            {
                // 동일한 속도인 경우 두 유닛의 순서를 랜덤하게 바꿈
                if (random.Next(2) == 0)
                {
                    Unit temp = tempUnits[i];
                    tempUnits[i] = tempUnits[i + 1];
                    tempUnits[i + 1] = temp;
                }
            }
        }

        return tempUnits;
    }

    /// <summary>
    /// 중복을 피해가는 함수
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    private (int, int) GetNonDuplicateRandomPair()
    {
        int a = Random.Range(1, 10);
        int b = Random.Range(1, 10);

        // 두 정수가 같을 경우 랜덤한 값으로 갱신
        if (a == b)
        {
            b = (b + 1) % 10 + 1;
        }

        return (a, b);
    }

}

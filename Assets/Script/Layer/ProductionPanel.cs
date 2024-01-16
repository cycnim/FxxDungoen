using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class ProductionPanel : MonoBehaviour
{
    public enum eProduction
    {
        None,
        FillLeft,
        FillRight,
        FillUp,
        FillDown,
        FillClock,
        FillCountClock,
        FadeINOut,
        CuttenCall,

        End
    }
    [SerializeField] private Image image1;
    [SerializeField] private Image image2;

    Color color = new Color(0, 0, 0, 1);
    float size = 0;

    //±âÁØÁ¡ÀÌ µÇ´Â x, y ÁÂÇ¥°ª
    

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            SetProduction(eProduction.FillLeft);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            SetProduction(eProduction.FillRight);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            SetProduction(eProduction.FillUp);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            SetProduction(eProduction.FillDown);
        }
        else if (Input.GetKeyDown(KeyCode.A)) 
        {
            SetProduction(eProduction.FillClock);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            SetProduction(eProduction.FillCountClock);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            SetProduction(eProduction.FadeINOut);
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(FillAmount(0, 0, Image.FillMethod.Horizontal));
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            SetProduction(eProduction.CuttenCall);
        }
        //Fill();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="production"></param>
    public void SetProduction(eProduction production)
    {
        switch (production)
        {
            case eProduction.None:
                break;
            case eProduction.FillLeft:
                Debug.Log("asdasd");
                StartCoroutine(FillAmount(0, 1, Image.FillMethod.Horizontal));
                break;
            case eProduction.FillRight:
                StartCoroutine(FillAmount(1, 0, Image.FillMethod.Horizontal));
                break;
            case eProduction.FillUp:
                StartCoroutine(FillAmount(0, 1, Image.FillMethod.Vertical));
                break;
            case eProduction.FillDown:
                StartCoroutine(FillAmount(1, 0, Image.FillMethod.Vertical));
                break;
            case eProduction.FillClock:
                StartCoroutine(FillAmount360(false));
                break;
            case eProduction.FillCountClock:
                StartCoroutine(FillAmount360(true));
                break;
            case eProduction.FadeINOut:
                StartCoroutine(FadeAmount());
                break;
            case eProduction.CuttenCall:
                StartCoroutine(CuttenCall(Image.FillMethod.Horizontal));
                break;


            case eProduction.End:
                break;
            default:
                break;
        }
    }


    /// <summary>
    /// ÇÑÂÊ¹æÇâ Ä¿ÅÙ ÃÑ6°¡Áö µÊ
    /// </summary>
    public IEnumerator FillAmount(int start, int end, Image.FillMethod fillMethod)
    {
        image1.fillMethod = fillMethod;
        image1.fillOrigin = start;

        while (size <= 1)
        {
            size += Time.deltaTime;
            image1.fillAmount = size;
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);
        
        image1.fillOrigin = end;
        while (size >= 0)
        {
            size -= Time.deltaTime;
            image1.fillAmount = size;
            yield return null;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public IEnumerator FillAmount360(bool fillClockwise)
    {
        image1.fillMethod = Image.FillMethod.Radial360;
        image1.fillOrigin = 0;
        image1.fillClockwise = fillClockwise;
        while (size <= 1)
        {
            size += Time.deltaTime;
            image1.fillAmount = size;
            yield return null;
        }
        
        yield return new WaitForSeconds(0.5f);
        image1.fillClockwise = !fillClockwise;
        while (size >= 0)
        {
            size -= Time.deltaTime;
            image1.fillAmount = size;
            yield return null;
        }
    }
    /// <summary>
    /// ÆäÀÌµåÀÎ¾Æ¿ô
    /// </summary>
    public IEnumerator FadeAmount()
    {
        image1.fillAmount = 1;
        image1.color = new Color(0, 0, 0, 0);
        while (size <= 1)
        {
            size += Time.deltaTime;
            image1.color = new Color(0,0,0, size);
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);
        while (size >= 0)
        {
            size -= Time.deltaTime;
            image1.color = new Color(0, 0, 0, size);
            yield return null;
        }
        image1.color = new Color(0, 0, 0, 1);
        image1.fillAmount = 0;
    }

    public IEnumerator CuttenCall(Image.FillMethod fillMethod)
    {
        image1.fillMethod = fillMethod;
        image2.fillMethod = fillMethod;


        image1.fillOrigin = 0;
        image1.fillOrigin = 1;

        while (size <= 1)
        {
            size += Time.deltaTime;
            image1.fillAmount = size;
            image2.fillAmount = size;
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        image1.fillOrigin = 1;
        image2.fillOrigin = 0;
        while (size >= 0)
        {
            size -= Time.deltaTime;
            image1.fillAmount = size;
            image2.fillAmount = size;
            yield return null;
        }
        
    }

}

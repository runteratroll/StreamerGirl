using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class TwichUser : MonoBehaviour
{
    public int abilityNumber;
    

    string []twichName = new string[] {"渋汎", "呼爽","鈎呪", "乞奄" };
    string []Chatingv= new string[] { "紫寓脊艦陥", "鈎呪析走亀", "せせせせせせ", "虞虞虞", "亀壕亀壕亀壕亀壕亀壕亀壕亀壕亀壕亀壕亀壕亀壕亀壕亀壕亀壕亀壕亀壕亀壕亀壕亀壕亀壕亀壕亀壕亀壕亀壕" };


    [SerializeField]
    private Transform Content;
    int randomUser = 0;
    int randomChating = 0;    
    [SerializeField]
    private Text chating = null;
    [SerializeField]
    private Text chatingContent = null;

    int chatingSpeed =1; //辰特 臣虞神澗 紗亀
    int NicknameColor = 0; //政煽 莞革績 事薗



    public void RandomColor()
    {
        Color color_title = Random.ColorHSV(0f,1f,0.5f,1f,0.5f,1f);
        //string color_title_code = ColorUtility.ToHtmlStringRGBA(color_title);
        chating.color = color_title;
    }

    public void Show()
    {
        transform.SetParent(Content.transform);
        gameObject.SetActive(true);

    }


    public void UpdateChating()
    {
       
        randomUser = Random.Range(0,twichName.Length);
        randomChating = Random.Range(0, Chatingv.Length );

        chating.text = (twichName[randomUser] + " : ");

        chatingContent.text = (Chatingv[randomChating]);

    }




}

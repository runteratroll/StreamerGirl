using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapPanels : MonoBehaviour
{

    public List<TapButton> tabButtons;
    public List<GameObject> contentsPanels;

    private void Awake()
    {

        ClickTab(0);
    }
    public void ClickTab(int id) //매개변수를 줘서 어느 버튼이 눌렸는지 확인해주겠습니다.
    {
        for(int i  =0; i < contentsPanels.Count; i++)
        {
            if(i == id)
            {
                contentsPanels[i].SetActive(true);
                tabButtons[i].Selected();
            }
            else
            {
                contentsPanels[i].SetActive(false);
                tabButtons[i].DeSelected();
            }
}
    }
}

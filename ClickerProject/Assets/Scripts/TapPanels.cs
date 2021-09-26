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
    public void ClickTab(int id) //�Ű������� �༭ ��� ��ư�� ���ȴ��� Ȯ�����ְڽ��ϴ�.
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

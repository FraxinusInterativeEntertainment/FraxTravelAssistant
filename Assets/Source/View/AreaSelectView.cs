using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AreaSelectView : UIViewBase
{
    public event Action RequestWikiGroupViewInfo = delegate { };
    public event Action<string> OpenStoryView = delegate { };
    [SerializeField]
    private Transform m_allButtons;
    void Awake()
    {
        AppFacade.instance.RegisterMediator(new AreaSelectViewMediator(this));
    }
    public override void Show()
    {
        base.Show();
        Clear();
        RequestWikiGroupViewInfo();
    }
    public void CheckWikiName(string _wikiName,bool _isShow)
    {
        for (int i = 0; i < m_allButtons.childCount; i++)
        {
            if (m_allButtons.GetChild(i).gameObject.name.Contains(_wikiName))
            {
                m_allButtons.GetChild(i).GetChild(0).GetComponent<Text>().text = _wikiName;
                if (_isShow==true)
                {
                    m_allButtons.GetChild(i).GetComponent<Button>().interactable = true;
                    m_allButtons.GetChild(i).GetComponent<Button>().onClick.AddListener(() => { OpenStoryView(_wikiName); });
                }
                else
                {
                    m_allButtons.GetChild(i).GetComponent<Button>().onClick.RemoveListener(() => { OpenStoryView(_wikiName); });
                    m_allButtons.GetChild(i).GetComponent<Button>().interactable = false;
                }
            }
        }
    }
    private void Clear()
    {
        if (m_allButtons.childCount==0)
            return;
        else
        {
            for (int i = 0; i < m_allButtons.childCount; i++)
            {
                m_allButtons.GetChild(i).GetChild(0).GetComponent<Text>().text = null;
                m_allButtons.GetChild(i).GetComponent<Button>().interactable = false;
                m_allButtons.GetChild(i).GetComponent<Button>().onClick.RemoveAllListeners();
            }
        }
    }
}

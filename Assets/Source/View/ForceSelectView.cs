using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceSelectView : UIViewBase
{
    public event Action RequestWikiGroupViewInfo = delegate { };
    public event Action<string> OpenStoryView = delegate { };
    [SerializeField]
    private Transform m_allButtons;
    void Awake()
    {
        AppFacade.instance.RegisterMediator(new ForceSelectViewMediator(this));
    }
    public override void Show()
    {
        base.Show();
        Clear();
        RequestWikiGroupViewInfo();
    }
    public void ShowButtonTest(int _index, string _text, bool _isShow)
    {
        m_allButtons.GetChild(_index).GetChild(0).GetComponent<Text>().text = _text;
         if (_isShow == true)
         {
             m_allButtons.GetChild(_index).GetComponent<Button>().interactable = true;
             m_allButtons.GetChild(_index).GetComponent<Button>().onClick.AddListener(() => { OpenStoryView(_text); });
         }
         else
         {
             m_allButtons.GetChild(_index).GetComponent<Button>().onClick.RemoveListener(() => { OpenStoryView(_text); }) ;
             m_allButtons.GetChild(_index).GetComponent<Button>().interactable = false;
         }
    }
    private void Clear()
    {
        if (m_allButtons.childCount == 0)
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

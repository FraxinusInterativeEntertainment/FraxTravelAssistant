using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EMailView : UIViewBase
{
    public event Action<string> OpenEmail = delegate { };
           
    public EMailInfo m_eMailInfo;
    public GameObject m_eMailContent;
    public PopEmail m_eMailPop;
    private void Start()
    {
        AppFacade.instance.RegisterMediator(new EMailViewMediator(this));
    }
    public void GetWikiGroupName(string _wikiGroupName)
    {
        OpenEmail(_wikiGroupName);
    }

}

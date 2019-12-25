using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DebugView : UIViewBase
{
    public event Action OnLogoutButton = delegate { };

    [SerializeField]
    private Button m_debugButton;
    [SerializeField]
    private Button m_logoutButton;
    
    void Start()
    {
        AppFacade.instance.RegisterMediator(new DebugViewMediator(this));
        
        m_debugButton.onClick.AddListener(() => { OnDebugButton(); });
        m_logoutButton.onClick.AddListener(() => { OnLogoutButton(); });
    }

    private void OnDebugButton()
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }
}

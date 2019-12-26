using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DebugView : UIViewBase
{
    public event Action OnLogoutButton = delegate { };

    [SerializeField]
    private GameObject m_debugPanel;
    [SerializeField]
    private Button m_debugButton;
    [SerializeField]
    private Button m_logoutButton;
    
    void Start()
    {
        AppFacade.instance.RegisterMediator(new DebugViewMediator(this));
        
        m_debugButton.onClick.AddListener(() => { OnDebugButton(); });
        m_logoutButton.onClick.AddListener(() => { OnLogoutButton(); });

        m_debugPanel.SetActive(false);
    }

    private void OnDebugButton()
    {
        m_debugPanel.SetActive(!m_debugPanel.activeSelf);
    }
}

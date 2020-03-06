using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DebugView : UIViewBase
{
    public event Action OnLogoutButton = delegate { };
    public event Action<string> SendMsgButton = delegate { };
    public event Action OnClickOpenGiveLikeView = delegate { };

    [SerializeField]
    private GameObject m_debugPanel;
    [SerializeField]
    private Button m_debugButton;
    [SerializeField]
    private Button m_logoutButton;

    [SerializeField]
    private Button m_sendMsgButton;
    [SerializeField]
    private InputField m_msgInputField; 
    
    [SerializeField]
    private Button m_giveLikeButton;
    void Start()
    {
        AppFacade.instance.RegisterMediator(new DebugViewMediator(this));
        
        m_debugButton.onClick.AddListener(() => { OnDebugButton(); });
        m_logoutButton.onClick.AddListener(() => { OnLogoutButton(); });
        m_sendMsgButton.onClick.AddListener(() => { SendMsgButton(m_msgInputField.text); });
        m_giveLikeButton.onClick.AddListener(() => { OnClickOpenGiveLikeView(); });
        m_debugPanel.SetActive(false);
    }
    private void OnDebugButton()
    {
        m_debugPanel.SetActive(!m_debugPanel.activeSelf);
    }
}

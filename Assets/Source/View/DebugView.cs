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
    public event Action<string,string> OnClickGetAllID = delegate { };
    public event Action ShowMofiTagID = delegate { };

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

    [SerializeField]
    private Button m_adminButton;
    [SerializeField]
    private GameObject m_adminPanel;
    [SerializeField]
    private Text m_oldMofiText;
    [SerializeField]
    private Text m_oldPosTagText;
    [SerializeField]
    private Button m_enterButton;
    [SerializeField]
    private InputField m_mofiID;
    [SerializeField]
    private InputField m_posTagID;
    [SerializeField]
    private Button m_closePanelButton;
    private string m_mofiId, m_posTagId;
    void Start()
    {
        AppFacade.instance.RegisterMediator(new DebugViewMediator(this));
        
        m_debugButton.onClick.AddListener(() => { OnDebugButton(); });
        m_logoutButton.onClick.AddListener(() => { OnLogoutButton(); });
        m_sendMsgButton.onClick.AddListener(() => { SendMsgButton(m_msgInputField.text); });
        m_giveLikeButton.onClick.AddListener(() => { OnClickOpenGiveLikeView(); });
        m_adminButton.onClick.AddListener(() => { OnClickOpenAdminPanel(); });
        m_closePanelButton.onClick.AddListener(() => { OnClickCloseAdminPanel(); });

        m_mofiID.onValueChanged.AddListener(GetMofiID);
        m_posTagID.onValueChanged.AddListener(GetPosTagID);
        m_enterButton.onClick.AddListener(() => { OnClickGetAllID(m_mofiId, m_posTagId); });

        m_debugPanel.SetActive(false);
        m_adminPanel.SetActive(false);
    }
    private void OnDebugButton()
    {
        m_debugPanel.SetActive(!m_debugPanel.activeSelf);
    }
    private void OnClickOpenAdminPanel()
    {
        m_adminPanel.SetActive(true);
        m_debugPanel.SetActive(false);
        ShowMofiTagID();
    }
    private void OnClickCloseAdminPanel()
    {
        m_adminPanel.SetActive(false);
        m_mofiID.text = "";
        m_posTagID.text = "";
    }
    private void GetMofiID(string _mofiId)
    {
        m_mofiId = _mofiId;
    }
    private void GetPosTagID(string _posTagId)
    {
        m_posTagId = _posTagId;
        Debug.Log("_posTagId；" + _posTagId);
    }
    public void InitAllId(string _mofi,string _posTag)
    {
        m_oldMofiText.text = _mofi;
        m_oldPosTagText.text = _posTag;
    }
}

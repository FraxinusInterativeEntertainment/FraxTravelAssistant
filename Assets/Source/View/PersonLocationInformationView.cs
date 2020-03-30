using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class PersonLocationInformationView : UIViewBase
{
    public event Action GetWikiRecordNumber = delegate { };
    public event Action<string> OpenWikiRecord = delegate { };

    [SerializeField]
    public Transform m_cards;
    [SerializeField]
    private Transform m_wikiRecordPanel;
    [SerializeField]
    private Button m_closePanelButton;
    [SerializeField]
    private Text m_wikiRecordDesText;
    [SerializeField]
    private Text m_wikiRecordTitleText;
    [SerializeField]
    private Image m_wikiRecordImage;


    private void Awake()
    {
        AppFacade.instance.RegisterMediator(new PersonLocationInformationMediator(this));
        m_closePanelButton.onClick.AddListener(ClosePanel);
    }
    public override void Show()
    {
        base.Show();
        Clear();
        GetWikiRecordNumber();
        m_wikiRecordPanel.gameObject.SetActive(false);
    }
    private void Clear()
    {
        if (m_wikiRecordPanel.gameObject.activeSelf==true)
        {
            m_wikiRecordPanel.gameObject.SetActive(false);
        }
        if (m_cards.childCount!=0)
        {
            for (int i = 0; i < m_cards.childCount; i++)
            {
                Destroy(m_cards.GetChild(i).gameObject);
            }
        }
       
    }
    public void ShowWikiRecordDes(object _obj)
    {
        WikiRecord wikiRecord = _obj as WikiRecord;
        m_wikiRecordTitleText.text = wikiRecord.Title;
        m_wikiRecordDesText.text = wikiRecord.Description;
    }
    public void GetWikiRecordName(string _wikiName)
    {
        OpenWikiRecord(_wikiName);
        m_wikiRecordPanel.gameObject.SetActive(true);
    }
    public void ShowImage(Sprite _sprite)
    {
        m_wikiRecordImage.sprite = _sprite;
    }
    private void ClosePanel()
    {
        m_wikiRecordPanel.gameObject.SetActive(false);
    }
}
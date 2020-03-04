using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestInfoView :UIViewBase
{
    public event Action<string> OnHintButton = delegate { };
    public event Action OnWikiButton = delegate { };

    [SerializeField]
    private Text m_stageTitleText;
    [SerializeField]
    private Text m_descriptionText;
    [SerializeField]
    public Button m_hintButton;
    [SerializeField]
    private Text m_hintText;
    [SerializeField]
    private Button m_wikiButton;
    private void Awake()
    {
        AppFacade.instance.RegisterMediator(new QuestInfoMediator(this));
        m_wikiButton.onClick.AddListener(() => { OnWikiButton(); });
        m_hintButton.onClick.AddListener(() => { OnHintButton(m_hintText.text); });
    }
    public override void Show()
    {
        base.Show();
        ClearLastInfo();
    }
    public void QuestInfoShow(object _date)
    {
        QuestInfoVO questInfoVO = _date as QuestInfoVO;
        string descriptionText= questInfoVO.msgContent.node_name + questInfoVO.msgContent.desc + questInfoVO.msgContent.location + questInfoVO.msgContent.character;
        m_descriptionText.text = descriptionText;
    }
    public void UpdataHintText(string _hintText)
    {
        m_hintText.text = _hintText;
    }
    private void ClearLastInfo()
    {
        m_stageTitleText.text = null;
        m_descriptionText.text = null;
        m_hintButton.image.sprite = null;
        m_hintText.text = null;
    }
}

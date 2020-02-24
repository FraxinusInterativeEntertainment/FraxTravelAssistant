using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestInfoView :UIViewBase
{
    public event Action OnWikiButton = delegate { };

    [SerializeField]
    private Text m_stageTitleText;
    [SerializeField]
    private Text m_descriptionText;
    [SerializeField]
    private Button m_hintButton;
    [SerializeField]
    private Text m_hintText;
    [SerializeField]
    private Button m_wikiButton;
    private void Start()
    {
        AppFacade.instance.RegisterMediator(new QuestInfoMediator(this));
        m_wikiButton.onClick.AddListener(() => { OnWikiButton(); });
    }
    public void QuestInfoShow(object _date)
    {
        QuestInfoVO questInfoVO = _date as QuestInfoVO;
        string descriptionText= questInfoVO.msgContent.node_name + questInfoVO.msgContent.desc + questInfoVO.msgContent.location + questInfoVO.msgContent.character;
        m_descriptionText.text = descriptionText;
    }
    public void UpdateHintText(object _obj)
    {
        m_hintText.text = _obj as string;
    }
}

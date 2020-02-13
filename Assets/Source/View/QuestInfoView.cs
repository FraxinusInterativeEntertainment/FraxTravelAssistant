using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestInfoView :UIViewBase
{
    [SerializeField]
    private Text m_stageTitleText;
    [SerializeField]
    private Text m_descriptionText;
    [SerializeField]
    private Button m_hintButton;
    [SerializeField]
    private Text m_hintText;
    private void Start()
    {
        AppFacade.instance.RegisterMediator(new QuestInfoMediator(this));
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

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
    private ServerCommunicationProxy serverCommunicationProxy;
    private void Start()
    {
        AppFacade.instance.RegisterMediator(new QuestInfoMediator(this));
        //测试假数据
        string websocketTest = "{'MsgType': 'quest', 'MsgContent': {'node_name': 'Liuqi', 'desc':'邀请你去', 'location': '楼下', 'character': '喝啤酒'}}";
        serverCommunicationProxy = new ServerCommunicationProxy();
        serverCommunicationProxy.WebSocketMessageHandler(websocketTest);
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

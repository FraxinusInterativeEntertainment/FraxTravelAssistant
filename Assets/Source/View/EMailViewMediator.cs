using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class EMailViewMediator : Mediator, IMediator
{
    public const string NAME = "EMailViewMediator";

    private  EMailView m_eMailView { get { return m_viewComponent as EMailView; } }

    public EMailViewMediator(EMailView _View) :base(NAME, _View)
    {
    }
    public override System.Collections.Generic.IList<string> ListNotificationInterests()
    {
        return new List<string>()
        {
            Const.Notification.UPDATE_EMAIL_NUMBER,
            Const.Notification.GET_WIKI_GROUP_INFO,
            Const.Notification.RECEIVE_WIKI_RECORD_INFO
        };
    }
    public override void HandleNotification(INotification _notification)
    {
        string name = _notification.Name;
        object vo = _notification.Body;
        switch (name)
        {
            case Const.Notification.UPDATE_EMAIL_NUMBER:
                MakeSureEmailNumber(vo);
                break;
            case Const.Notification.GET_WIKI_GROUP_INFO:
                ReceiveWikiGroupInfo(vo);
                break;
            case Const.Notification.RECEIVE_WIKI_RECORD_INFO:
                break;
        }
    }
    private void MakeSureEmailNumber(object _msg)
    {
        EMailVO eMailVO = _msg as EMailVO;
        for (int i = 0; i < eMailVO.msgContent.Length; i++)
        {
            EMailInfo eMailInfo = GameObject.Instantiate(m_eMailView.m_eMailInfo);
            eMailInfo.transform.SetParent(m_eMailView.m_eMailContent.transform,false);
            eMailInfo.transform.SetAsFirstSibling();
            eMailInfo.m_wiki_Group_Name = eMailVO.msgContent[i].ToString();
        }
    }

    private void ReceiveWikiGroupInfo(object _msg)
    {
        WikiGroupInfoVO wikiGroupInfoVO = _msg as WikiGroupInfoVO;
        m_eMailView.m_eMailPop.m_wikiGroupName.text = wikiGroupInfoVO.WikiGroupName;
        m_eMailView.m_eMailPop.m_wikiGroupDes.text = wikiGroupInfoVO.WikiGroupDescription;
        m_eMailView.m_eMailPop.m_wikiGroupImage.sprite = Resources.Load<Sprite>("Textures/Images/Wiki/" + wikiGroupInfoVO.WikiGroupImage);
        SendNotification(Const.Notification.GET_WIKI_RECORD_INFO, m_eMailView.m_eMailPop.m_wikiGroupName);
    }
    private void ReceiveWikiRecordInfo(object _msg)
    {
        WikiGroupInfoVO wikiGroupInfoVO = _msg as WikiGroupInfoVO;
        m_eMailView.m_eMailPop.m_wikiRecordName.text = wikiGroupInfoVO.Wiki_Records.WikiRecordName;
        m_eMailView.m_eMailPop.m_wikiRecordImage.sprite = Resources.Load<Sprite>("Textures/Images/Wiki/"+wikiGroupInfoVO.Wiki_Records.WikiRecordImage);
    }
    public void TryOpenEmail(string _wikiGroupName)
    {
        SendNotification(Const.Notification.GET_EMAIL_NUM, _wikiGroupName);
    }
}

using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceSelectViewMediator : Mediator, IMediator
{
    public const string NAME = "ForceSelectViewMediator";
    private ForceSelectView m_forceView{ get { return m_viewComponent as ForceSelectView; } }
    private AreaSelectProxy m_areaSelectProxy;
    
    public ForceSelectViewMediator(ForceSelectView _view) : base(NAME, _view)
    {
        m_areaSelectProxy = Facade.RetrieveProxy(AreaSelectProxy.NAME) as AreaSelectProxy;
        m_forceView.RequestWikiGroupViewInfo += TryRequestWikiInfo;
        m_forceView.OpenStoryView += OpenStoryView;
    }
    public override IList<string> ListNotificationInterests()
    {
        return new List<string>()
        {
            Const.Notification.BACK_AVAILABLE_FORCE_WIKI_GROUP_INFO
        };
    }
    public override void HandleNotification(INotification _notification)
    {
        string name = _notification.Name;
        object vo = _notification.Body;
        switch (name)
        {
            case Const.Notification.BACK_AVAILABLE_FORCE_WIKI_GROUP_INFO:
                CheckWikiGroupLocked(vo);
                break;
        }
    }
    private void CheckWikiGroupLocked(object _obj)
    {
        AvailableWikiGroupInfo[] availableWikiGroupInfos = _obj as AvailableWikiGroupInfo[];
        for (int i = 0; i < availableWikiGroupInfos.Length; i++)
        {
            if (availableWikiGroupInfos[i].unlocked == true)
            {
                m_forceView.ShowButtonTest(i, availableWikiGroupInfos[i].name, true);
            }
            else
            {
                m_forceView.ShowButtonTest(i, "???", false);
                
            }
        }
    }
    private void OpenStoryView(string _text)
    {
        m_areaSelectProxy.wikiGroupName = _text;
        AppFacade.instance.SendNotification(Const.Notification.LOAD_UI_FORM, Const.UIFormNames.STORY_FORM);
        SendNotification(Const.Notification.SEND_WIKI_GROUP_NAME, _text);
    }
    private void TryRequestWikiInfo()
    {
        SendNotification(Const.Notification.GET_FORCE_LOCK_WIKI_GROUP_INFO);
    }
}

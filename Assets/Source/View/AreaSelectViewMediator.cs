using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;
public class AreaSelectViewMediator : Mediator, IMediator
{
    public const string NAME = "AreaSelectViewMediator";

    private AreaSelectProxy m_areaSelectProxy;
    private AreaSelectView m_wikiTypeSelectView { get { return m_viewComponent as AreaSelectView; } }
    public AreaSelectViewMediator(AreaSelectView _view) : base(NAME, _view)
    {
        m_areaSelectProxy = Facade.RetrieveProxy(AreaSelectProxy.NAME) as AreaSelectProxy;
        m_wikiTypeSelectView.RequestWikiGroupViewInfo += RequestWikiInfo;
        m_wikiTypeSelectView.OpenStoryView += OpenStoryView;
    }
    public override IList<string> ListNotificationInterests()
    {
        return new List<string>()
        {
            Const.Notification.BACK_AVAILABLE_AREA_WIKI_GROUP_INFO
        };
    }
    public override void HandleNotification(INotification _notification)
    {
        string name = _notification.Name;
        object vo = _notification.Body;
        switch (name)
        {
            case Const.Notification.BACK_AVAILABLE_AREA_WIKI_GROUP_INFO:
                 CheckWikiGroupLocked(vo);
                break;
        }
    }
    private void RequestWikiInfo()
    {
        
        SendNotification(Const.Notification.GET_AREA_LOCK_WIKI_GROUP_INFO);
    }
    private void CheckWikiGroupLocked(object _obj)
    {
        AvailableWikiGroupInfo[] availableWikiGroupInfos = _obj as AvailableWikiGroupInfo[];
        for (int i = 0; i < availableWikiGroupInfos.Length; i++)
        {
            m_wikiTypeSelectView.CheckWikiName(availableWikiGroupInfos[i].name, availableWikiGroupInfos[i].unlocked);
        }
    }
    private void OpenStoryView(string _text)
    {
       
        m_areaSelectProxy.wikiGroupName = _text;
        AppFacade.instance.SendNotification(Const.Notification.LOAD_UI_FORM, Const.UIFormNames.STORY_FORM);
        SendNotification(Const.Notification.SEND_WIKI_GROUP_NAME, _text);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class BackGroundStoryViewMediator : Mediator, IMediator
{
    public const string NAME = "BackGroundStoryViewMediator";

    private BackGroundStoryView  m_storyView { get { return m_viewComponent as BackGroundStoryView; } }
    public override IList<string> ListNotificationInterests()
    {
        return new List<string>()
        {
            Const.Notification.BACK_BACKGROUND_STORY
        };
    }
    public override void HandleNotification(INotification _notification)
    {
        string name = _notification.Name;
        object vo = _notification.Body;
        switch (name)
        {
            case Const.Notification.BACK_BACKGROUND_STORY:
                ChangeBackGroundStory(vo);
                break;
        }
    }
    public BackGroundStoryViewMediator(BackGroundStoryView _view) : base(NAME, _view)
    {
        m_storyView.OpenStory += TryOpenStoryView;
        m_storyView.OpenPersonLocation += TryOpenPersonLocationInfo;
    }
    private void TryOpenStoryView()
    {
        AreaSelectProxy m_areaSelectProxy = Facade.RetrieveProxy(AreaSelectProxy.NAME) as AreaSelectProxy;
        SendNotification(Const.Notification.GET_WIKI_GROUP_BACKGROUND_STORY, m_areaSelectProxy.wikiGroupName);
    }
    private void TryOpenPersonLocationInfo()
    {
        AppFacade.instance.SendNotification(Const.Notification.LOAD_UI_FORM, Const.UIFormNames.PERSON_LOCATION_INFO_FORM);
    }
    private void ChangeBackGroundStory(object _obj)
    {
        WikiGroupInfo wikiGroupInfo = _obj as WikiGroupInfo;
        m_storyView.ShowBackGroundStory(wikiGroupInfo.Title, wikiGroupInfo.Description);
        Addressables.LoadAssetAsync<Sprite>(wikiGroupInfo.Image.ToString()).Completed += OnImageInstantiated;
    }
    private void OnImageInstantiated(AsyncOperationHandle<Sprite> _obj)
    {
        Sprite sprite = _obj.Result;
        m_storyView.ShowImage(sprite);
    }
}

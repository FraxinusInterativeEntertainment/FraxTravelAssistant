using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class BackGroundStoryProxy : Proxy, IProxy, IResponder
{
    public const string NAME = "BackGroundStoryProxy";

    public WikiGroupInfo wikiGroupInfo;
    public BackGroundStoryProxy() : base(NAME) { }

    public void TryGetWikiGroupBackGroundStory(string _wikiName)
    {
        BackGroundStoryDelegate backGroundStoryDelegate = new BackGroundStoryDelegate(this, _wikiName);
        backGroundStoryDelegate.GetBackGroundStory();
    }
    public void OnFault(object _data)
    {
        throw new System.NotImplementedException();
    }

    public void OnResult(object _data)
    {
        AppFacade.instance.SendNotification(Const.Notification.BACK_BACKGROUND_STORY, _data);
        wikiGroupInfo = _data as WikiGroupInfo;
    }
}

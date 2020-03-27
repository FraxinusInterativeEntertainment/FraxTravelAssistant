using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class BackGroundStoryCommand : SimpleCommand
{
    public override void Execute(INotification _notification)
    {
        object obj = _notification.Body;
        string name = _notification.Name;
        BackGroundStoryProxy backGroundStoryProxy= Facade.RetrieveProxy(BackGroundStoryProxy.NAME) as BackGroundStoryProxy;
        switch (name)
        {
            case Const.Notification.GET_WIKI_GROUP_BACKGROUND_STORY:
                backGroundStoryProxy.TryGetWikiGroupBackGroundStory(obj as string);
                break;
        }
    }
}


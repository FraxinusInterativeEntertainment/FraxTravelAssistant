using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;
public class AreaSelectCommand : SimpleCommand
{
    public override void Execute(INotification _notification)
    {
        object obj = _notification.Body;
        string name = _notification.Name;
        AreaSelectProxy areaSelectProxy;
        areaSelectProxy = Facade.RetrieveProxy(AreaSelectProxy.NAME) as AreaSelectProxy;
        switch (name)
        {
            case Const.Notification.GET_AREA_LOCK_WIKI_GROUP_INFO:
                areaSelectProxy.TryGetLockedWikiGroup();
                break;
            case Const.Notification.SEND_WIKI_GROUP_NAME:
                areaSelectProxy.SetWikiGroupName(obj.ToString());
                break;
        }
    }
}

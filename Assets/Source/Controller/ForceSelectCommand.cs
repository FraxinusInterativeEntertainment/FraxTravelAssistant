using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;
public class ForceSelectCommand : SimpleCommand
{
    public override void Execute(INotification _notification)
    {
        object obj = _notification.Body;
        string name = _notification.Name;
        ForceSelectProxy  forceSelectProxy;
        forceSelectProxy = Facade.RetrieveProxy(ForceSelectProxy.NAME) as ForceSelectProxy;
        switch (name)
        {
            case Const.Notification.GET_FORCE_LOCK_WIKI_GROUP_INFO:
                forceSelectProxy.TryGetLockedWikiGroup();
                break;
        }
    }
}

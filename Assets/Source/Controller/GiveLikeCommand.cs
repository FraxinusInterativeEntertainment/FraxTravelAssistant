using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;
public class GiveLikeCommand : SimpleCommand
{
    public override void Execute(INotification _notification)
    {
        object obj = _notification.Body;
        GiveLikeProxy giveLikeProxy;
        giveLikeProxy = Facade.RetrieveProxy(GiveLikeProxy.NAME) as GiveLikeProxy;
        string name = _notification.Name;
        switch (name)
        {
            case Const.Notification.GET_ACTOR_INFO:
                giveLikeProxy.GetActorInfo();
                break;
        }
    }
}

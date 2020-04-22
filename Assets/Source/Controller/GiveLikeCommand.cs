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
        GiveLikeProxy2 giveLikeProxy2;
        giveLikeProxy2 = Facade.RetrieveProxy(GiveLikeProxy2.NAME) as GiveLikeProxy2;
        string name = _notification.Name;
        switch (name)
        {
            case Const.Notification.GET_ACTOR_INFO:
                giveLikeProxy.GetActorInfo();
                break;
            case Const.Notification.SET_ACTOR_ID:
                giveLikeProxy2.SetActorID(obj as string);
                break;
        }
    }
}

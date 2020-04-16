using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveLikeCommand2 : SimpleCommand
{
    public override void Execute(INotification _notification)
    {
        object obj = _notification.Body;
        GiveLikeProxy2 giveLikeProxy;
        giveLikeProxy = Facade.RetrieveProxy(GiveLikeProxy2.NAME) as GiveLikeProxy2;
        string name = _notification.Name;
        switch (name)
        {
            case Const.Notification.SET_ACTOR_ID:
                giveLikeProxy.SetActorID(obj as string);
                break;
        }
    }
}

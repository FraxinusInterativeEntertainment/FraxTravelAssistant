using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class HintInfoCommand : SimpleCommand
{
    public override void Execute(INotification _notification)
    {
        object obj = _notification.Body;
        string name = _notification.Name;
        HintInfoProxy hintInfoProxy;
        hintInfoProxy = Facade.RetrieveProxy(HintInfoProxy.NAME) as HintInfoProxy;
        switch (name)
        {
            case Const.Notification.REQUEST_HINT_INFO:
                hintInfoProxy.TryRequestHintInfo();
                break;
            case Const.Notification.SEND_HINT_NAME:
                hintInfoProxy.RequestHintName(obj);
                break;

        }
    }
}

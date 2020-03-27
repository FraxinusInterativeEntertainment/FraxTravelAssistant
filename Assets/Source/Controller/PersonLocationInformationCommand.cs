using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class PersonLocationInformationCommand : SimpleCommand
{
    public override void Execute(INotification _notification)
    {
        object obj = _notification.Body;
        PersonLocationInformationProxy personLocationInformationProxy;
        personLocationInformationProxy = Facade.RetrieveProxy(PersonLocationInformationProxy.NAME) as PersonLocationInformationProxy;

        string name = _notification.Name;
        switch (name)
        {
            case Const.Notification.GET_WIKI_RECORD_STORY:
                personLocationInformationProxy.TryRequestWikiRecord(obj as string);
                break;
        }
    }
}

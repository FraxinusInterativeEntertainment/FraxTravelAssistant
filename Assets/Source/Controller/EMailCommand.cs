using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class EMailCommand : SimpleCommand
{
    public override void Execute(INotification _notification)
    {
        object obj = _notification.Body;
        EMailProxy eMailProxy;
        eMailProxy = Facade.RetrieveProxy(EMailProxy.NAME) as EMailProxy;
        WikiRecordProxy wikiRecordProxy;
        wikiRecordProxy = Facade.RetrieveProxy(WikiRecordProxy.NAME) as WikiRecordProxy;
        string name = _notification.Name;
        switch (name)
        {
            case Const.Notification.GET_EMAIL_NUM:
                eMailProxy.TryGetWikiGroupInfo(obj.ToString());
                break;
            case Const.Notification.GET_WIKI_RECORD_INFO:
                wikiRecordProxy.TryGetWikiRecordInfo(obj.ToString());
                break;
        }
    }
}

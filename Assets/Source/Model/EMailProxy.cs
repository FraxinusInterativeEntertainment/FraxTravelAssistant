using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class EMailProxy : Proxy, IProxy, IResponder
{
    public const string NAME = "EMailProxy";

    public EMailProxy() : base(NAME) { }

    public void TryGetWikiGroupInfo(string _wikiGroupName)
    {
       EMailDelegate eMailDelegate = new EMailDelegate(this, _wikiGroupName);
       eMailDelegate.GetWikiGroupInfo();
    }
    public void OnResult(object _data)
    {
        Debug.Log("服务器返回的数据" + _data.ToString());
        AppFacade.instance.SendNotification(Const.Notification.GET_WIKI_GROUP_INFO, _data);
    }
    public void OnFault(object _data)
    {
        Debug.Log("服务器返回的数据" + _data);
    }
}

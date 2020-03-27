using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class WikiRecordProxy : Proxy, IProxy, IResponder
{
    public const string NAME = "WikiRecordProxy";

    public WikiRecordProxy() : base(NAME) { }

    public void TryGetWikiRecordInfo(string _wikiName)
    {
       
    }
    public void OnResult(object _data)
    {
        Debug.Log("服务器返回的数据" + _data.ToString());
        AppFacade.instance.SendNotification(Const.Notification.RECEIVE_WIKI_RECORD_INFO, _data);
    }
    public void OnFault(object _data)
    {
        Debug.Log("服务器返回的数据" + _data);
    }

   
}

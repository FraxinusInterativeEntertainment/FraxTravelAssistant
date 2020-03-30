using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class PersonLocationInformationProxy : Proxy, IProxy, IResponder
{
    public const string NAME = "PersonLocationInformationProxy";

    public PersonLocationInformationProxy() : base(NAME) { }
   
    public void TryRequestWikiRecord(string _wikiRecordName)
    {
        WikiRecordDelegate wikiRecordDelegate = new WikiRecordDelegate(this, _wikiRecordName);
        wikiRecordDelegate.TryGetWikiRecordInfo();
    }

    public void OnResult(object _data)
    {
        AppFacade.instance.SendNotification(Const.Notification.BACK_WIKI_RECORD_STORY, _data);
    }
    public void OnFault(object _data)
    {
        Debug.Log("请求失败返回的数据=" + _data.ToString());
    }

}

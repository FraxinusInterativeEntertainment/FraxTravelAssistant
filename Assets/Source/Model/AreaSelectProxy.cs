using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;
public class AreaSelectProxy : Proxy, IProxy, IResponder
{
    public const string NAME = "AreaSelectProxy";

    public AreaSelectProxy() : base(NAME) { }

    public string wikiGroupName { get; set; }
    public void TryGetLockedWikiGroup()
    {
        AreaSelectDelegate areaSelectDelegate = new AreaSelectDelegate(this);
        areaSelectDelegate.GetLockedWikiGroupInfo();
    }
    public void SetWikiGroupName(string _wikiGroupName)
    {
        wikiGroupName = _wikiGroupName;
    }
    public void OnResult(object _data)
    {
        AppFacade.instance.SendNotification(Const.Notification.BACK_AVAILABLE_AREA_WIKI_GROUP_INFO, _data);
    }
    public void OnFault(object _data)
    {
        Debug.Log("服务返回错误执行的");
    }
}


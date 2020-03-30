using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceSelectProxy : Proxy, IProxy, IResponder
{
    public const string NAME = "ForceSelectProxy";

    public ForceSelectProxy() : base(NAME) { }
    public void TryGetLockedWikiGroup()
    {
        ForceSelectDelegate forceSelectDelegate = new ForceSelectDelegate(this);
        forceSelectDelegate.GetLockedWikiGroupInfo();
    }
    public void OnResult(object _data)
    {
        AppFacade.instance.SendNotification(Const.Notification.BACK_AVAILABLE_FORCE_WIKI_GROUP_INFO, _data);
    }
    public void OnFault(object _data)
    {
        Debug.Log("服务返回错误执行的");
    }

  
}

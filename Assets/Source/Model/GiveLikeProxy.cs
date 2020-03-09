using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveLikeProxy : Proxy, IProxy, IResponder
{
    public const string NAEM = "GiveLikeProxy";

    public GiveLikeProxy() : base(NAME) { }

    public  void GetActorInfo()
    {
        GiveLikeDelegate giveLikeDelegate = new GiveLikeDelegate(this);
        giveLikeDelegate.GetActorInfo();
    }
    public void OnResult(object _data)
    {
        AppFacade.instance.SendNotification(Const.Notification.SHOW_ACTOR_INFO, _data);
    }
    public void OnFault(object _data)
    {
        Debug.Log("Have Not Actor Info");
    }

  


}

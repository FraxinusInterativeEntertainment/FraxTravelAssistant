using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditUserInfoProxy : Proxy, IProxy, IResponder
{
    public const string NAME = "EditUserInfoProxy";
    public EditUserInfoProxy() : base(NAME) { }

    public void TryGetUserInfo()
    {
        EditUserInfoDelegate editUserInfoDelegate = new EditUserInfoDelegate(this);
        editUserInfoDelegate.GetUserInfo();
    }

    public void OnFault(object _data)
    {
        Debug.Log("HaveNotWserInfo");
    }
    public void OnResult(object _data)
    {
        AppFacade.instance.SendNotification(Const.Notification.BACK_EXTRA_USER_INFO, _data);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class UserInfoProxy : Proxy,IProxy,IResponder
{
    public const string NAME = "UserInfoProxy";

    public UserInfoProxy() : base(NAME) { }

    public void CheckUserInfoExist()
    {
        UserInfoDelegate userInfoDelegate = new UserInfoDelegate(this);
        userInfoDelegate.GetUserInfo();
    }

    public void OnFault(object _data)
    {
        Debug.Log(_data as string); //用户信息不存在
        AppFacade.instance.SendNotification(Const.Notification.LOAD_UI_FORM, Const.UIFormNames.USER_INFORMATION_FORM);
    }

    public void OnResult(object _data)
    {
        Debug.Log("_data存在");
        AppFacade.instance.SendNotification(Const.Notification.LOAD_UI_ROOT_FORM, Const.UIFormNames.PRE_GAME_FORM);
    }
}

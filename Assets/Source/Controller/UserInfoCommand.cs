using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfoCommand : SimpleCommand
{
    public override void Execute(INotification _notification)
    {
        object obj = _notification.Body;
        UserInfoProxy userInfoProxy;
        userInfoProxy = Facade.RetrieveProxy(UserInfoProxy.NAME) as UserInfoProxy;
        string name = _notification.Name;
        switch (name)
        {
            case Const.Notification.CHECK_USER_INFO_EXIST:
                userInfoProxy.CheckUserInfoExist();
                break;
        }
    }
}

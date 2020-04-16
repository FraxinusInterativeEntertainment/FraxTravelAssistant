using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditUserInfoCommand : SimpleCommand
{
    public override void Execute(INotification _notification)
    {
        object obj = _notification.Body;
        string name = _notification.Name;
        EditUserInfoProxy editUserInfoProxy;
        editUserInfoProxy = Facade.RetrieveProxy(EditUserInfoProxy.NAME) as EditUserInfoProxy;
        switch (name)
        {
            case Const.Notification.EDIT_USER_USER_INFO:
                editUserInfoProxy.TryGetUserInfo();
                break;
        }
    }
}

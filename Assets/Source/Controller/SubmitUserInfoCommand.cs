using PureMVC.Patterns;
using PureMVC.Interfaces;
using UnityEngine;

public class SubmitUserInfoCommand :SimpleCommand
{
    public override void Execute(INotification _notification)
    {
        object obj = _notification.Body;
        SubmitUserInfoProxy submitUserInfoProxy;
        submitUserInfoProxy = Facade.RetrieveProxy(SubmitUserInfoProxy.NAME) as SubmitUserInfoProxy;
        string name = _notification.Name;
        switch (name)
        {
            case Const.Notification.SUBMIT_USER_INFO:
                submitUserInfoProxy.SendUserInfo(obj);
                break;


        }

    }
}

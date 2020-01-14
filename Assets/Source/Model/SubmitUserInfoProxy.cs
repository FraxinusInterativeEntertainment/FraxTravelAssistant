using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class SubmitUserInfoProxy : Proxy, IProxy, IResponder
{
    public const string NAME = "SubmitUserInfoProxy";

    public SubmitUserInfoProxy() : base(NAME) { }
    public void SendUserInfo(object _data)
    {
        SubmitUserInfoDelegate submitUserInfoDelegate = new SubmitUserInfoDelegate(this, _data as SubmitUserInfoVO);
        submitUserInfoDelegate.SubmitUserInfoService();
    }
    void IResponder.OnFault(object _data)
    {
        Debug.Log("User information提交失败"+_data as string);
    }

    void IResponder.OnResult(object _data)
    {
        Debug.Log("User information 提交成功" + _data as string);
    }
}

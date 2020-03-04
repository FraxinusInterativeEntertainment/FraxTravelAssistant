using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class HintInfoProxy : Proxy, IProxy, IResponder
{
    public const string NAME = "HintInfoProxy";

    public HintInfoProxy() : base(NAME) { }
    public string requestHintName { get; set; }
    public void RequestHintName(object _hintName)
    {
        requestHintName = _hintName as string;
    }
    public void TryRequestHintInfo()
    {
        HintInfoDelegate questInfoDelegate = new HintInfoDelegate(this, requestHintName);
        questInfoDelegate.GetHintInfo();
    }

    public void OnResult(object _data)
    {
        AppFacade.instance.SendNotification(Const.Notification.BACK_HINT_INFO, _data);
    }
    public void OnFault(object _data)
    {
        Debug.Log("请求失败返回的数据=" + _data.ToString());
    }

   
}

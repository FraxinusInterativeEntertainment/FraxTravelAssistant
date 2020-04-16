using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveLikeProxy2 : Proxy, IProxy, IResponder
{
    public const string NAEM = "GiveLikeProxy2";
    public GiveLikeProxy2() : base(NAME) { }
    public void SetActorID(string _userId)
    {
        GiveLikeDelegate2 giveLikeDelegate2 = new GiveLikeDelegate2(this, _userId);
        giveLikeDelegate2.EvaluateUser();
    }
    public void OnFault(object _data)
    {
        Debug.Log("提交失败" + _data as string);
    }

    public void OnResult(object _data)
    {
        Debug.Log("提交成功"+ _data as string);
    }
}

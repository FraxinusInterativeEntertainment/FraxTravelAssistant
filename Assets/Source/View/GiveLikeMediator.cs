using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveLikeMediator : Mediator, IMediator
{
    public const string NAME = "GiveLikeMediator";
    private GiveLikeView m_giveLikeView { get { return m_viewComponent as GiveLikeView; } }
    public GiveLikeMediator(GiveLikeView _View) : base(NAME, _View)
    {
        m_giveLikeView.GetActorID += TrySetActorId;
    }
    public override IList<string> ListNotificationInterests()
    {
        return new List<string>()
        {
            Const.Notification.BACK_SUBMIT_INFO
        };
    }
    public override void HandleNotification(INotification _notification)
    {
        string name = _notification.Name;
        object vo = _notification.Body;
        switch (name)
        {
            case Const.Notification.BACK_SUBMIT_INFO:
                break;
        }
    }
    private void TrySetActorId(string _actorID)
    {
        SendNotification(Const.Notification.SET_ACTOR_ID, _actorID);
    }
}

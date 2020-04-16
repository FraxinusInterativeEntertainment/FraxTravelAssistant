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
    private void TrySetActorId(string _actorID)
    {
        SendNotification(Const.Notification.SET_ACTOR_ID, _actorID);
    }
}

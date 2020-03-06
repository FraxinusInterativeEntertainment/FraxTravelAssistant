using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class GiveLikeViewMediator : Mediator, IMediator
{
    public const string NAME = "GiveLikeViewMediator";
   
    private GiveLikeView m_giveLikeView { get { return m_viewComponent as GiveLikeView; } }
    public GiveLikeViewMediator(GiveLikeView _View) : base(NAME,_View)
    {
        m_giveLikeView.GetGiveLikeInfo += ResponseGiveLikeInfo;
    }
    public void ResponseGiveLikeInfo()
    {
        SendNotification(Const.Notification.GET_ACTOR_INFO);
    }
    public override System.Collections.Generic.IList<string> ListNotificationInterests()
    {
        return new List<string>()
        {
            Const.Notification.SHOW_ACTOR_INFO,
        };
    }
    public override void HandleNotification(INotification notification)
    {
        string name = notification.Name;
        object vo = notification.Body;

        switch (name)
        {
            case Const.Notification.SHOW_ACTOR_INFO:
                InstActorInfo(vo);
                break;
        }
    }
    private List<ActorDetailsModel> actorList = null;
    private int index = 0;
    private void InstActorInfo(object _obj)
    {
        actorList = _obj as List<ActorDetailsModel>;
        for (int i = 0; i < actorList.Count; i++)
        {
            Addressables.InstantiateAsync("ActorInfo").Completed += OnActorCardInstantiated;
        }
    }
    private void OnActorCardInstantiated(AsyncOperationHandle<GameObject> _obj)
    {
        ActorInfo actorInfo = _obj.Result.GetComponent<ActorInfo>();
        actorInfo.transform.SetParent(m_giveLikeView.m_actorInfoShowContent);
        actorInfo.Show(actorList[index++]);
        m_giveLikeView.ContinueShow();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class DebugViewMediator : Mediator, IMediator
{
    public const string NAME = "DebugViewMediator";

    protected DebugView m_debugView { get { return m_viewComponent as DebugView; } }

    public DebugViewMediator(DebugView _view) : base(NAME, _view)
    {
        m_debugView.OnLogoutButton += TryLogout;
        m_debugView.SendMsgButton += TrySendMsg;
        m_debugView.OnClickOpenGiveLikeView += OpenGiveLikeView;
        m_debugView.OnClickGetAllID += TrySetId;
        m_debugView.ShowMofiTagID += TryGetID;
    }

    public override System.Collections.Generic.IList<string> ListNotificationInterests()
    {
        return new List<string>()
        {

        };
    }

    public override void HandleNotification(INotification notification)
    {
        string name = notification.Name;
        object vo = notification.Body;

        switch (name)
        {

        }
    }

    private void TryLogout()
    {
        SendNotification(Const.Notification.LOGOUT);
    }
    private void TrySendMsg(string _msg)
    {
        ServerCommunicationProxy serverCommunicationProxy = new ServerCommunicationProxy();
        serverCommunicationProxy.DebugMessage(_msg);
    }

    private void OpenGiveLikeView()
    {
        SendNotification(Const.Notification.GAME_CLOSED);
    }
    private void TrySetId(string _mofiID, string _posTagID)
    {
        Debug.Log("mofiID==" + _mofiID + "         posTagID" + _posTagID);
        PlayerPrefs.SetString("MofiID", _mofiID);
        PlayerPrefs.SetString("PosTagID", _posTagID);
        TryGetID();
    }
    private void TryGetID()
    {
        string mofiID = PlayerPrefs.GetString("MofiID");
        string posTagID = PlayerPrefs.GetString("PosTagID");
        if (mofiID == null)
        {
            mofiID = "没有mofiID";
        }
        if (posTagID==null)
        {
            posTagID = "没有poTagID";
        }
        m_debugView.InitAllId(mofiID,posTagID);
       Debug.Log( PlayerPrefs.GetString("mofiID"));
       Debug.Log( PlayerPrefs.GetString("posTagID"));
    }
}

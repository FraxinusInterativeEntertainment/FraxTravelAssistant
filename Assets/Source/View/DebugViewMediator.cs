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
    
}

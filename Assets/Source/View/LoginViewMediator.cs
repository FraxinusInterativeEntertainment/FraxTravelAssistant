﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class LoginViewMediator : Mediator, IMediator
{
    public const string NAME = "LoginViewMediator";

    protected LoginView m_loginView { get { return m_viewComponent as LoginView; } }

    public LoginViewMediator(LoginView _view) : base(NAME, _view)
    {
        m_loginView.TryLogin += OnTryLogin;
    }
    
    public override System.Collections.Generic.IList<string> ListNotificationInterests()
    {
        return new List<string>()
        {
            Const.Notification.LOGIN_SUCCESS,
            Const.Notification.LOGIN_FAIL
        };
    }

    public override void HandleNotification(INotification notification)
    {
        string name = notification.Name;
        object vo = notification.Body;

        switch (name)
        {
            case Const.Notification.LOGIN_SUCCESS:
                m_loginView.OnLoginSuccess(vo);
                break;
            case Const.Notification.LOGIN_FAIL:
                m_loginView.OnLoginFail(vo);
                break;
        }
    }

    private void OnTryLogin()
    {
        SendNotification(Const.Notification.QR_SCAN_LOGIN);
    }
}

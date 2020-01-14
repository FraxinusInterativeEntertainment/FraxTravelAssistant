using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class AppFacade : Facade, IFacade
{
    public const string STARTUP = "Startup";
    public const string LOGIN = "login";

    private static AppFacade m_instance;

    public static AppFacade instance
    {
        get{
            if (m_instance == null)
            {
                m_instance = new AppFacade();
            }
            return m_instance;
        }
    }
    
    protected override void InitializeController()
    {
        base.InitializeController();
        RegisterCommand(STARTUP, typeof(StartupCommand));
        RegisterCommand(Const.Notification.QR_SCAN_LOGIN, typeof(LoginCommand));
        RegisterCommand(Const.Notification.LOAD_UI_FORM, typeof(UICommand));
        RegisterCommand(Const.Notification.LOAD_UI_ROOT_FORM, typeof(UICommand));
        RegisterCommand(Const.Notification.BACK_TO_LAST_FORM, typeof(UICommand));
        RegisterCommand(Const.Notification.LOGIN_SUCCESS, typeof(MainFSMCommand));
        RegisterCommand(Const.Notification.LOGOUT_SUCCESS, typeof(MainFSMCommand));
        RegisterCommand(Const.Notification.CHECK_LOGIN_STATUS, typeof(LoginStatusCommand));
        RegisterCommand(Const.Notification.LOGOUT, typeof(LogoutCommand));
        RegisterCommand(Const.Notification.CHECK_USER_INFO_EXIST, typeof(UserInfoCommand));
        RegisterCommand(Const.Notification.SUBMIT_USER_INFO, typeof(SubmitUserInfoCommand));
    }

    public void startup()
    {
        SendNotification(STARTUP);
    }
}

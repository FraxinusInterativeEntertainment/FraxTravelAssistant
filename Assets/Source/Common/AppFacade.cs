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
        RegisterCommand(Const.Notification.GO_TO_HOME_FORM, typeof(UICommand));
        RegisterCommand(Const.Notification.BACK_TO_LAST_FORM, typeof(UICommand));
        RegisterCommand(Const.Notification.LOGIN_SUCCESS, typeof(MainFSMCommand));
        RegisterCommand(Const.Notification.LOGOUT_SUCCESS, typeof(MainFSMCommand));
        RegisterCommand(Const.Notification.CHECK_LOGIN_STATUS, typeof(LoginStatusCommand));
        RegisterCommand(Const.Notification.LOGOUT, typeof(LogoutCommand));
        RegisterCommand(Const.Notification.CHECK_USER_INFO_EXIST, typeof(UserInfoCommand));
        RegisterCommand(Const.Notification.SUBMIT_USER_INFO, typeof(SubmitUserInfoCommand));
        RegisterCommand(Const.Notification.CONNECT_TO_WS_SERVER, typeof(ServerCommunicationCommand));
        RegisterCommand(Const.Notification.SETUP_CONNECTION_WITH_SERVER, typeof(ServerCommunicationCommand));
        RegisterCommand(Const.Notification.UPDATE_QUEST_INFO_TASK, typeof(QuestInfoCommand));
        RegisterCommand(Const.Notification.UPDATE_EMAIL_NUMBER, typeof(EMailCommand));
        RegisterCommand(Const.Notification.GET_EMAIL_NUM, typeof(EMailCommand));
        RegisterCommand(Const.Notification.GET_WIKI_RECORD_INFO, typeof(EMailCommand));
        RegisterCommand(Const.Notification.RECEIVE_WIKI_RECORD_INFO, typeof(EMailCommand));
    }

    public void startup()
    {
        SendNotification(STARTUP);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class NavigationBarViewMediator : Mediator, IMediator
{
    public const string NAME = "MainMenuViewMediator";

    private NavigationBarView m_navigationBarView { get { return m_viewComponent as NavigationBarView; } }

    public NavigationBarViewMediator(NavigationBarView _view) : base(NAME, _view)
    {
        m_navigationBarView.OnBackButton += Back;
        m_navigationBarView.OnHomeButton += Home;
        m_navigationBarView.OnUserInfoButton += UserInfo;
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

    public void Home()
    {
        AppFacade.instance.SendNotification(Const.Notification.LOAD_UI_ROOT_FORM, Const.UIFormNames.PRE_GAME_FORM);
    }

    public void Back()
    {
        AppFacade.instance.SendNotification(Const.Notification.BACK_TO_LAST_FORM);
    }
    public void UserInfo()
    {
        AppFacade.instance.SendNotification(Const.Notification.LOAD_UI_ROOT_FORM, Const.UIFormNames.USER_INFORMATION_FORM);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class MainMenuViewMediator : Mediator, IMediator
{
    public const string NAME = "MainMenuViewMediator";

    private MainMenuView m_mainMenuView { get { return m_viewComponent as MainMenuView; } }

    public MainMenuViewMediator(MainMenuView _view) : base(NAME, _view)
    {
        m_mainMenuView.OnAssisantModeButton += ShowAssistantModeWindow;
        m_mainMenuView.OnWorldBackGroundButton += ShowWorldBackGroundWindow;
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

    public void ShowAssistantModeWindow()
    {
        AppFacade.instance.SendNotification(Const.Notification.LOAD_UI_FORM, Const.UIFormNames.TRAVEL_ASSITANT_MODE_FORM);
    }
    public void ShowWorldBackGroundWindow()
    {
        AppFacade.instance.SendNotification(Const.Notification.LOAD_UI_FORM, Const.UIFormNames.WIKI_TYPE_SELECTION_FORM);
    }
}

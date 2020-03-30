using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;
public class WikiTypeSelectionViewMediator : Mediator, IMediator
{
    public const string NAME = "WikiTypeSelectionViewMediator";

    private WikiTypeSelectionView m_wikiTypeSelectView { get { return m_viewComponent as WikiTypeSelectionView; } }

    public WikiTypeSelectionViewMediator(WikiTypeSelectionView _view) : base(NAME, _view)
    {
        m_wikiTypeSelectView.OpenAreaSelectionButton += OpenAreaSelectView;
        m_wikiTypeSelectView.OpenForceSelectionButton += OpenForceSelectView;
        m_wikiTypeSelectView.OpenOtherSelectionButton += OpenOtherSelectView;
    }
    private void OpenAreaSelectView()
    {
        AppFacade.instance.SendNotification(Const.Notification.LOAD_UI_FORM, Const.UIFormNames.AREA_SELECTION_FORM);
    }
    private void OpenForceSelectView()
    {
         AppFacade.instance.SendNotification(Const.Notification.LOAD_UI_FORM, Const.UIFormNames.FORCE_SELECTION_FORM);
    }
    private void OpenOtherSelectView()
    {

    }

}

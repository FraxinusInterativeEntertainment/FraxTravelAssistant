﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginState : FSMState
{
    public LoginState(int _id, FSMSystem _fsmSystem) : base(_id, _fsmSystem) { }

    public override void DoBeforeEntering()
    {
        base.DoBeforeEntering();
        Debug.Log("Enter login state");
        //AppFacade.instance.SendNotification(Const.Notification.LOAD_SCENE, new SceneVO(Const.SceneIndex.MAIN_PANEL_SCENE));

        //AppFacade.instance.SendNotification(Const.Notification.LOAD_UI_FORM, Const.UIFormNames.LOGIN_FORM);

        AppFacade.instance.SendNotification(Const.Notification.CHECK_LOGIN_STATUS);

        //UIManager.instance.ShowForm("MainForm");
    }
}

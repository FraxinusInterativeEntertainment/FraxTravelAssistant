using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreGameState : FSMState
{
    public PreGameState(int _id, FSMSystem _fsmSystem) : base(_id, _fsmSystem) { }

    public override void DoBeforeEntering()
    {
        base.DoBeforeEntering();

        //AppFacade.instance.SendNotification(Const.Notification.LOAD_SCENE, new SceneVO(Const.SceneNames.PRE_GAME_SCENE));
         //AppFacade.instance.SendNotification(Const.Notification.LOAD_UI_ROOT_FORM, Const.UIFormNames.PRE_GAME_FORM);
         AppFacade.instance.SendNotification(Const.Notification.CHECK_USER_INFO_EXIST);
        Debug.Log("Enter Pre game State");
    }
}

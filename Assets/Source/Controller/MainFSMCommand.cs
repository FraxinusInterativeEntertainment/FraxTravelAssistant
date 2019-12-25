using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using UnityEngine.SceneManagement;


public class MainFSMCommand : SimpleCommand
{
    public override void Execute(INotification _notification)
    {
        object obj = _notification.Body;
        string name = _notification.Name;

        switch (name)
        {
            case Const.Notification.LOGIN_SUCCESS:
                //SceneManager.LoadScene(Const.SceneNames.MAIN_PANEL_SCENE);
                GameManager.instance.ChangeMainFSMState(MainFSMStateID.PreGame);
                break;
            
        }
    }
}

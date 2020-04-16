using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;

public class ModelPreCommand : SimpleCommand
{
    public override void Execute(PureMVC.Interfaces.INotification notification)
    {
        Facade.RegisterProxy(new LoginProxy());
        Facade.RegisterProxy(new ServerCommunicationProxy());
        Facade.RegisterProxy(new LoginStatusProxy());
        Facade.RegisterProxy(new LogoutProxy());
        Facade.RegisterProxy(new UserInfoProxy());
        Facade.RegisterProxy(new SubmitUserInfoProxy());
        Facade.RegisterProxy(new WebSocketTokenProxy());
        Facade.RegisterProxy(new EMailProxy());
        Facade.RegisterProxy(new WikiRecordProxy());
        Facade.RegisterProxy(new HintInfoProxy());
        Facade.RegisterProxy(new GiveLikeProxy());
        Facade.RegisterProxy(new GiveLikeProxy2());
        Facade.RegisterProxy(new AreaSelectProxy());
        Facade.RegisterProxy(new ForceSelectProxy());
        Facade.RegisterProxy(new BackGroundStoryProxy());
        Facade.RegisterProxy(new PersonLocationInformationProxy());
        Facade.RegisterProxy(new EditUserInfoProxy());
    }
}

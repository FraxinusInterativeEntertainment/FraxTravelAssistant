using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;
public class QuestInfoMediator : Mediator, IMediator
{
    public const string NAME = "QuestInfoMediator";


    private QuestInfoView m_questInfoView { get { return m_viewComponent as QuestInfoView; } }

    public QuestInfoMediator(QuestInfoView _View) : base(NAME, _View)
    {
        

    }
   
    public override System.Collections.Generic.IList<string> ListNotificationInterests()
    {
        return new List<string>()
        {
            Const.Notification.UPDATE_QUEST_INFO_TASK,
            Const.Notification.UPDATE_HINT_TEXT
        };
    }
    public override void HandleNotification(INotification notification)
    {
        string name = notification.Name;
        object vo = notification.Body;
        switch (name)
        {
            case Const.Notification.UPDATE_QUEST_INFO_TASK:
                m_questInfoView.QuestInfoShow(vo);
                break;
            case Const.Notification.UPDATE_HINT_TEXT:
                m_questInfoView.UpdateHintText(vo); 
                break;
        }
    }
}

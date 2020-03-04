using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class QuestInfoMediator : Mediator, IMediator
{
    public const string NAME = "QuestInfoMediator";

    Stack<string> hintLists = new Stack<string>();
    private QuestInfoView m_questInfoView { get { return m_viewComponent as QuestInfoView; } }

    public QuestInfoMediator(QuestInfoView _View) : base(NAME, _View)
    {
        m_questInfoView.OnWikiButton += OpenEmail;
        m_questInfoView.OnHintButton += OpenHintView;
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
                UpdateHintText(vo);
                break;
        }
    }
    private void OpenHintView(string _hiniName)
    {
        SendNotification(Const.Notification.SEND_HINT_NAME, _hiniName);
        SendNotification(Const.Notification.LOAD_UI_FORM, Const.UIFormNames.HINT_FORM);
        hintLists.Pop();
        if (hintLists.Count!=0)
        {
            m_questInfoView.UpdataHintText(hintLists.Peek());
        }
        else
        {
            m_questInfoView.m_hintButton.interactable = false;
        }
    }
    private void OpenEmail()
    {

    }
    private void UpdateHintText(object _data)
    {
        HintList hintList = _data as HintList;
        for (int i = 0; i < hintList.msgContent.Length; i++)
        {
            hintLists.Push(hintList.msgContent[i]);
            if (m_questInfoView.m_hintButton.interactable==false)
            {
                m_questInfoView.m_hintButton.interactable = true;
            }
        }
        m_questInfoView.UpdataHintText(hintLists.Peek());
        string instateThumImage = "Hint_Thum_" + hintLists.Peek();
        Addressables.LoadAssetAsync<Sprite>(instateThumImage).Completed += OnImageInstantiated;
    }
    private void OnImageInstantiated(AsyncOperationHandle<Sprite> _obj)
    {
        m_questInfoView.m_hintButton.image.sprite = _obj.Result;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;
using UnityEngine.ResourceManagement.AsyncOperations;

public class HintViewMediator : Mediator, IMediator
{
    public const string NAME = "HintViewMediator";
    private HintView m_hintView { get { return m_viewComponent as HintView; } }

    public HintViewMediator(HintView _View) : base(NAME, _View)
    {
        m_hintView.CloseHint += TryCloseHintView;
        m_hintView.RequestViewInfo += TryGetViewInfo;
    }
    public override IList<string> ListNotificationInterests()
    {
        return new List<string>()
        {
            Const.Notification.BACK_HINT_INFO
        };
    }
    public override void HandleNotification(INotification _notification)
    {
        string name = _notification.Name;
        object vo = _notification.Body;
        switch (name)
        {
            case Const.Notification.BACK_HINT_INFO:
                OpenHintView(vo);
                break;
        }
    }
    private void OpenHintView(object _obj)
    {
        WikiGroupInfo hintInfo = _obj as WikiGroupInfo;
        m_hintView.m_hintNameText.text = hintInfo.ID;
        m_hintView.m_hintDescribeText.text = hintInfo.Description;
        string imageName = hintInfo.Image;
        Addressables.LoadAssetAsync<Sprite>(imageName).Completed += OnImageInstantiated;
    }
    private void OnImageInstantiated(AsyncOperationHandle<Sprite> _obj)
    {
        m_hintView.m_hintImage.sprite = _obj.Result;
    }
    private void TryGetViewInfo()
    {
        string wikiName = HintsName.Instance.hintName;
        SendNotification(Const.Notification.REQUEST_HINT_INFO, wikiName);
    }
    private void TryCloseHintView()
    {
        AppFacade.instance.SendNotification(Const.Notification.BACK_TO_LAST_FORM);
    }
}

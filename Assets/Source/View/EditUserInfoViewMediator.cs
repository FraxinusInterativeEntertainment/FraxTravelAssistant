using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using UnityEngine.UI;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.AddressableAssets;

public class EditUserInfoViewMediator : Mediator, IMediator
{
    public const string NAME = "EditUserInfoViewMediator";
    private EditUserInfoView m_editUserInfoView { get { return m_viewComponent as EditUserInfoView; } }

    public EditUserInfoViewMediator(EditUserInfoView _View) : base(NAME, _View)
    {
        m_editUserInfoView.OpenUserInfo += TryOpenUserInfo;
        m_editUserInfoView.SetUserInfo += TrySetUserInfo;
    }
    public override IList<string> ListNotificationInterests()
    {
        return new List<string>()
        {
            Const.Notification.BACK_EXTRA_USER_INFO
        };
    }
    public override void HandleNotification(INotification _notification)
    {
        string name = _notification.Name;
        object vo = _notification.Body;
        switch (name)
        {
            case Const.Notification.BACK_EXTRA_USER_INFO:
                UpdateUserInfo(vo);
                break;
        }
    }
    private void TryOpenUserInfo()
    {
        AppFacade.instance.SendNotification(Const.Notification.LOAD_UI_FORM,Const.UIFormNames.USER_INFORMATION_FORM);
    }
    private void UpdateUserInfo(object _obj)
    {
        UserExtraInfo userExtraInfo = _obj as UserExtraInfo;
        m_editUserInfoView.ShowUserInfo(userExtraInfo);
        string imageName = userExtraInfo.avatar;
        Debug.Log("ImageName==" + imageName);
        Addressables.LoadAssetAsync<Sprite>(imageName).Completed += OnImageInstantiated;
    }
    private void OnImageInstantiated(AsyncOperationHandle<Sprite> _obj)
    {
        m_editUserInfoView.InstateImage(_obj.Result);
    }
    private void TrySetUserInfo()
    {
        SendNotification(Const.Notification.EDIT_USER_USER_INFO);
    }
}

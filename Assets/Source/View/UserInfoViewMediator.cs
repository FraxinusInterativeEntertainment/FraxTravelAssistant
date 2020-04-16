using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class UserInfoViewMediator : Mediator,IMediator
{
    public const string NAME = "UserInfoViewMediator";


    private UserInfoView m_userInfoView { get { return m_viewComponent as UserInfoView; } }

    public UserInfoViewMediator(UserInfoView _View):base(NAME,_View)
    {
        m_userInfoView.OnClickChangeHeadIconButton += ChangeHeadIcon;
        m_userInfoView.OnClickSubmitUserInfo += SubmitUserInfo;
        m_userInfoView.OnClickSetIconName += SetHeadIcon;
    }
    public override void HandleNotification(INotification notification)
    {
        base.HandleNotification(notification);
    }
    public void ChangeHeadIcon()
    {
        m_userInfoView.ShowChangeHeadIconPop(true);
    }
    private void OnImageInstantiated(AsyncOperationHandle<GameObject> _obj)
    {
        Protrait protInfo = _obj.Result.GetComponent<Protrait>();
        protInfo.transform.SetParent(m_userInfoView.m_protShowContent);
    }
    public void SubmitUserInfo(SubmitUserInfoVO m_submitUserInfoVO)
    {
        if (m_userInfoView.m_nickNameInputField.text != null && m_userInfoView.m_nickNameInputField.text.Length != 0)
        {

            m_userInfoView.RedHightLightshow(false);
            SendNotification(Const.Notification.SUBMIT_USER_INFO, m_submitUserInfoVO);
        }
        else
        {
            Debug.Log("有信息没填好");
            m_userInfoView.RedHightLightshow(true);
        }
    }
    private void SetHeadIcon(string _iconName)
    {
        m_userInfoView.ShowChangeHeadIconPop(false);
        Debug.Log("传过来的==" + _iconName.ToString());
        Addressables.LoadAssetAsync<Sprite>(_iconName).Completed += OnImageInstantiated;
    }
    private void OnImageInstantiated(AsyncOperationHandle<Sprite> _obj)
    {
        Sprite sprite = _obj.Result;
        m_userInfoView.ChangeIcon(sprite);
       
    }
}

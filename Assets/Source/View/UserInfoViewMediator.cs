using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using UnityEngine.UI;

public class UserInfoViewMediator : Mediator,IMediator
{
    public const string NAME = "UserInfoViewMediator";


    private UserInfoView m_userInfoView { get { return m_viewComponent as UserInfoView; } }

    public UserInfoViewMediator(UserInfoView _View):base(NAME,_View)
    {

        m_userInfoView.OnClickChangeHeadIconButton += ChangeHeadIcon;
        m_userInfoView.OnClickSubmitUserInfo += SubmitUserInfo;

    }
    public override void HandleNotification(INotification notification)
    {
        base.HandleNotification(notification);
    }
    public void ChangeHeadIcon()
    {
        m_userInfoView.ShowChangeHeadIconPop();

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
}

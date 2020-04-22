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
        m_userInfoView.OnClickSubmitUserInfo += SubmitUserInfo;
        m_userInfoView.OnClickSetIconName += SetHeadIcon;
        m_userInfoView.InstateIconSprites+= TryInstateIconSprites;
    }
    public override void HandleNotification(INotification notification)
    {
        base.HandleNotification(notification);
    }
    public void SubmitUserInfo(SubmitUserInfoVO m_submitUserInfoVO)
    {
        if (m_userInfoView.m_nickNameInputField.text != null && m_userInfoView.m_nickNameInputField.text.Length != 0)
        {
            m_userInfoView.RedHightLightshow(false);
            SendNotification(Const.Notification.SUBMIT_USER_INFO, m_submitUserInfoVO);
        }
        else
            m_userInfoView.RedHightLightshow(true);
    }
    private void SetHeadIcon(string _iconName)
    {
        m_userInfoView.ChangeHeadIconPop();
        Addressables.LoadAssetAsync<Sprite>(_iconName).Completed += OnImageInstantiated;
    }
    private void OnImageInstantiated(AsyncOperationHandle<Sprite> _obj)
    {
        Sprite sprite = _obj.Result;
        m_userInfoView.ChangeIcon(sprite);
    }
    private void TryInstateIconSprites()
    {
        Addressables.LoadAssetsAsync<Sprite>(m_userInfoView.m_portrait,null).Completed += TextureLoaded;
    }
    IList<Sprite> loadedSprites;
    List<Sprite> currentSprite = new List<Sprite>();
    int index = 0;
    void TextureLoaded(AsyncOperationHandle<IList<Sprite>> obj)
    {
        loadedSprites =obj.Result;
        for (int i = 0; i < loadedSprites.Count; i++)
        {
            currentSprite.Add(loadedSprites[i]);
            Addressables.InstantiateAsync("HeadIcon").Completed += HeadIconInstantiated;
        }
    }
    private void HeadIconInstantiated(AsyncOperationHandle<GameObject> _obj)
    {
        Image headIcon = _obj.Result.GetComponent<Image>();
        headIcon.sprite = currentSprite[index];
        index++;
        headIcon.transform.SetParent(m_userInfoView.m_protShowContent);
        headIcon.transform.GetComponent<Button>().onClick.AddListener(() => { SetHeadIcon(headIcon.transform.GetComponent<Image>().sprite.ToString()); });
    }
 }


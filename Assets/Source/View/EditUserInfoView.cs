using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditUserInfoView : UIViewBase
{
    public event Action OpenUserInfo = delegate { };
    public event Action SetUserInfo = delegate { };

    [SerializeField]
    private Text m_nameText;
    [SerializeField]
    private Text m_sexText;
    [SerializeField]
    private Image m_iconImage;
    [SerializeField]
    private Text m_brithdayText;
    [SerializeField]
    private Button m_editUserInfoButton;
    void Awake()
    {
        AppFacade.instance.RegisterMediator(new EditUserInfoViewMediator(this));
        m_editUserInfoButton.onClick.AddListener(() => { OpenUserInfo(); });
    }
    public override void Show()
    {
        base.Show();
        Clear();
        SetUserInfo();
    }
    private void Clear()
    {
        m_nameText.text = null;
        m_sexText.text = null;
        m_iconImage.sprite = null;
        m_brithdayText.text = null;
    }
    public void ShowUserInfo(UserExtraInfo _userExtraInfo)
    {
        m_nameText.text = _userExtraInfo.nickname;
        m_sexText.text = _userExtraInfo.sex;
        m_brithdayText.text = _userExtraInfo.birthday;
    } 
    public void InstateImage(Sprite _sprite)
    {
        m_iconImage.sprite = _sprite;
    }
}

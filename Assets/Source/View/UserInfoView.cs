using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInfoView : UIViewBase
{
    public event Action OnClickChangeHeadIconButton = delegate { };
    public event Action<SubmitUserInfoVO> OnClickSubmitUserInfo = delegate { };
    
    private SubmitUserInfoVO m_submitUserInfoVO;
    [SerializeField]
    private Button m_heandIconButton;
    [SerializeField]
    private GameObject m_headIconPop;
    [SerializeField]
    private Dropdown m_dropdown;

    [SerializeField]
    private Sprite[] m_sprites;
    [SerializeField]
    private Image m_arrows;
    [SerializeField]
    private Text m_showText;
    [SerializeField]
    private GameObject m_choiceTimeObj;
    [SerializeField]
    private Button m_timeChoiceButton;
    private bool isShowChoiceTimeBool = false;

    [SerializeField]
    private Button m_submitButton;
    [SerializeField]
    public InputField m_nickNameInputField;  
    [SerializeField]
    public Image m_redHightLight;

   

    private void Start()
    {
        AppFacade.instance.RegisterMediator(new UserInfoViewMediator(this));

        m_heandIconButton.onClick.AddListener(() => { OnClickChangeHeadIconButton(); });
        m_timeChoiceButton.onClick.AddListener(() => { OnClickTimeChoiceButton(); });
        m_submitButton.onClick.AddListener(() => { OnClickSubmitUserInfo(m_submitUserInfoVO); });
        m_showText.text = DateTime.Now.ToString("yyyy/MM/dd");
        m_choiceTimeObj.SetActive(false);

        m_submitUserInfoVO = new SubmitUserInfoVO();
        m_submitUserInfoVO.UserInfo_Born = m_showText.text;
        m_nickNameInputField.onValueChanged.AddListener((string _text) => { m_submitUserInfoVO.UserInfo_NickName = _text; });
        //这里直接吧初始头像名字传进去，后续改
        m_submitUserInfoVO.UserInfo_HeadIcon = m_heandIconButton.image.sprite.ToString();
        m_dropdown.onValueChanged.AddListener(ShowChangeUserSex);
    }
    private void Update()
    {
        if (m_choiceTimeObj.activeSelf)
        {
            isShowChoiceTimeBool = true;
        }
        else
        {
            isShowChoiceTimeBool = false;
        }
    }
    public void OnClickTimeChoiceButton()
    {
        if (!isShowChoiceTimeBool)
        {
            m_choiceTimeObj.SetActive(true);
            m_arrows.sprite = m_sprites[1];
        }
        else
        {
            m_choiceTimeObj.SetActive(false);
            isShowChoiceTimeBool = false;
            m_arrows.sprite = m_sprites[0];
            if (DatePickerGroup.m_selectTime.ToString("yyyy/MM/dd").Substring(0, 3) == "000")
            {
                m_showText.text = DateTime.Now.ToString("yyyy/MM/dd");
                m_submitUserInfoVO.UserInfo_Born = m_showText.text;
            }
            else
            {
                m_showText.text = DatePickerGroup.m_selectTime.ToString("yyyy/MM/dd");

                m_submitUserInfoVO.UserInfo_Born = m_showText.text;
            }
        }
    }
    public void ShowChangeHeadIconPop()
    {
        m_headIconPop.SetActive(!m_headIconPop.activeSelf);
    }
    private void ShowChangeUserSex(int _value)
    {
        switch (_value)
        {
            case 0:
                Debug.Log("value==" + _value);
                m_submitUserInfoVO.UserInfo_Sex = _value;
                break;
            case 1:
                Debug.Log("value==" + _value);
                m_submitUserInfoVO.UserInfo_Sex = _value;
                break;
            case 2:
                Debug.Log("value==" + _value);
                m_submitUserInfoVO.UserInfo_Sex = _value;
                break;
        }
    }
}

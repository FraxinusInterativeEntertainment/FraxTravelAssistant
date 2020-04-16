using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInfoView : UIViewBase
{
    public event Action OnClickChangeHeadIconButton = delegate { };
    public event Action<SubmitUserInfoVO> OnClickSubmitUserInfo = delegate { };
    public event Action<string> OnClickSetIconName = delegate { };

    private SubmitUserInfoVO m_submitUserInfoVO;
    [SerializeField]
    private Button m_headIconButton;
    [SerializeField]
    public Transform m_protShowContent;
    [SerializeField]
    private GameObject m_headIconPop;
    [SerializeField]
    private Button m_closeHeadIconPopBtn;
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

    [SerializeField]
    private Button m_submitButton;
    [SerializeField]
    public InputField m_nickNameInputField;  
    [SerializeField]
    private Image m_redHightLight;
    
    private void Start()
    {
        AppFacade.instance.RegisterMediator(new UserInfoViewMediator(this));

        m_headIconButton.onClick.AddListener(() => { OnClickChangeHeadIconButton(); });
        m_timeChoiceButton.onClick.AddListener(() => { OnClickTimeChoiceButton(); });
        m_submitButton.onClick.AddListener(() => { OnClickSubmitUserInfo(m_submitUserInfoVO); });
        m_showText.text = DateTime.Now.ToString("yyyy/MM/dd");
        m_choiceTimeObj.SetActive(false);

        m_submitUserInfoVO = new SubmitUserInfoVO();
        m_submitUserInfoVO.UserInfo_Born = m_showText.text;
        m_nickNameInputField.onValueChanged.AddListener((string _text) => { m_submitUserInfoVO.UserInfo_NickName = _text; });
       
        m_dropdown.onValueChanged.AddListener(ShowChangeUserSex);
    }
    public void OnClickTimeChoiceButton()
    {
        if (m_choiceTimeObj.activeSelf==false)
        {
            m_choiceTimeObj.SetActive(true);
            m_arrows.sprite = m_sprites[1];
        }
        else
        {
            m_choiceTimeObj.SetActive(false);
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
    public void ShowChangeHeadIconPop(bool _isShow)
    {
        m_headIconPop.SetActive(_isShow);
        if (_isShow==true)
        {
            m_closeHeadIconPopBtn.onClick.AddListener(ChangeHeadIconPop);
            for (int i = 0; i < m_protShowContent.childCount; i++)
            {
                string name = m_protShowContent.GetChild(i).GetComponent<Image>().sprite.ToString();
                m_protShowContent.GetChild(i).GetComponent<Button>().onClick.AddListener(() => { OnClickSetIconName(name); });
            }
        }
    }
    private void ChangeHeadIconPop()
    {
        ShowChangeHeadIconPop(false);
    }
    public void ChangeIcon(Sprite _icon)
    {
        
        m_headIconButton.image.sprite = _icon;
        m_submitUserInfoVO.UserInfo_HeadIcon = m_headIconButton.image.sprite.ToString();
        Debug.Log(m_submitUserInfoVO.UserInfo_HeadIcon);
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
    public void RedHightLightshow(bool _show)
    {
        m_redHightLight.gameObject.SetActive(_show);
    }
    private void OnDestroy()
    {
        m_headIconPop.SetActive(false);
        for (int i = 0; i < m_protShowContent.childCount; i++)
        {
            m_protShowContent.GetChild(i).GetComponent<Button>().onClick.RemoveAllListeners();
        }
    }
}

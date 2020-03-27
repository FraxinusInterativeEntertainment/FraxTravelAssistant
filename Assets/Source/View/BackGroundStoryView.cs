using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundStoryView : UIViewBase
{
    public event Action OpenStory = delegate { };
    public event Action OpenPersonLocation = delegate { };

    [SerializeField]
    private Text m_wikiTitleText;
    [SerializeField]
    private Image m_wikiGroupImage;
    [SerializeField]
    private Text m_backGroundStory;
    [SerializeField]
    private Button m_desButton;
    private void Awake()
    {
        AppFacade.instance.RegisterMediator(new BackGroundStoryViewMediator(this));
        m_desButton.onClick.AddListener(() => { OpenPersonLocation(); });
    }
    public override void Show()
    {
        base.Show();
        Clear();
        OpenStory();
    }
    private void Clear()
    {
        m_wikiTitleText.text = null;
        m_backGroundStory.text = null;
        m_wikiGroupImage.sprite = null;
    }
    public void ShowBackGroundStory(string _title, string _description)
    {
        m_wikiTitleText.text = _title;
        m_backGroundStory.text = _description;
    }
    public void ShowImage(Sprite _sprite)
    {
        m_wikiGroupImage.sprite = _sprite;
    }
}

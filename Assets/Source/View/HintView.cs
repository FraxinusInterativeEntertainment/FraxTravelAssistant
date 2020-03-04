using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintView : UIViewBase
{
    public event Action CloseHint = delegate { };
    public event Action RequestViewInfo = delegate { };
    
    [SerializeField]
    private Button m_closeButton;
    [SerializeField]
    public Text m_hintNameText;
    [SerializeField]
    public Text m_hintDescribeText;
    [SerializeField]
    public Image m_hintImage;
    void Awake()
    {
        AppFacade.instance.RegisterMediator(new HintViewMediator(this));
        m_closeButton.onClick.AddListener(() => { CloseHint(); });
    }
    public override void Show()
    {
        base.Show();
        Clear();
        RequestViewInfo();
    }
    private void Clear()
    {
        m_hintNameText.text = null;
        m_hintDescribeText.text = null;
        m_hintImage.sprite = null;
    }
    void OnDestroy()
    {
        AppFacade.instance.RemoveMediator(HintViewMediator.NAME);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MainMenuView : UIViewBase
{
    public event Action OnAssisantModeButton = delegate { };
    public event Action OnWorldBackGroundButton = delegate { };

    [SerializeField]
    private Button m_assistantModeButton;
    [SerializeField]
    private Button m_worldBackGround;
    private void Start()
    {
        AppFacade.instance.RegisterMediator(new MainMenuViewMediator(this));

        m_assistantModeButton.onClick.AddListener(() => { OnAssisantModeButton(); });
        m_worldBackGround.onClick.AddListener(() => { OnWorldBackGroundButton(); });
    }
}

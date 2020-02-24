using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MainMenuView : UIViewBase
{
    public event Action OnAssisantModeButton = delegate { };

    [SerializeField]
    private Button m_assistantModeButton;
    private void Start()
    {
        AppFacade.instance.RegisterMediator(new MainMenuViewMediator(this));

        m_assistantModeButton.onClick.AddListener(() => { OnAssisantModeButton(); });
       
    }
}

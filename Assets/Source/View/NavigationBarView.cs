using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class NavigationBarView : UIViewBase
{
    public event Action OnBackButton = delegate { };
    public event Action OnHomeButton = delegate { };

    [SerializeField]
    private Button m_backButton;
    [SerializeField]
    private Button m_homeButton;

    private void Start()
    {
        AppFacade.instance.RegisterMediator(new NavigationBarViewMediator(this));

        m_backButton.onClick.AddListener(() => { OnBackButton(); });
        m_homeButton.onClick.AddListener(() => { OnHomeButton(); });
    }
}

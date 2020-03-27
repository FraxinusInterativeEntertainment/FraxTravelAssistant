using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WikiTypeSelectionView : UIViewBase
{
    public event Action OpenAreaSelectionButton = delegate { };
    public event Action OpenForceSelectionButton = delegate { };
    public event Action OpenOtherSelectionButton = delegate { };

    [SerializeField]
    private Button m_areaSelectButton;
    [SerializeField]
    private Button m_forceSelectButton;
    [SerializeField]
    private Button m_otherSelectionButton;
    void Start()
    {
        AppFacade.instance.RegisterMediator(new WikiTypeSelectionViewMediator(this));

        m_areaSelectButton.onClick.AddListener(() => { OpenAreaSelectionButton(); });
        m_forceSelectButton.onClick.AddListener(() => { OpenForceSelectionButton(); });
        m_otherSelectionButton.onClick.AddListener(() => { OpenOtherSelectionButton(); });
    }
}

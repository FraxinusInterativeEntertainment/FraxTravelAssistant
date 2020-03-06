using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;

public class GiveLikeView : UIViewBase
{
    public event Action GetGiveLikeInfo = delegate { };
    [SerializeField]
    public Button m_continue;
    [SerializeField]
    public Transform m_actorInfoShowContent;
    public ActorInfo m_actorInfo;
    void Awake()
    {
        AppFacade.instance.RegisterMediator(new GiveLikeViewMediator(this));
        m_continue.onClick.AddListener(GoOnAndContinue);
    }
    public override void Show()
    {
        base.Show();
        GetGiveLikeInfo();
    }
    public void ContinueShow()
    {
        if (m_continue.gameObject.activeSelf==false)
        {
            m_continue.gameObject.SetActive(true);
            m_continue.transform.SetAsLastSibling();
        }
        else
        {
            m_continue.transform.SetAsLastSibling();
        }
    }
    private void GoOnAndContinue()
    {
        transform.gameObject.SetActive(false);
    }
}

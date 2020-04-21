using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GiveLikeView : UIViewBase
{
    public event Action GetGiveLikeInfo = delegate { };
    public event Action<string> GetActorID = delegate { };
    [SerializeField]
    public Button m_continue;
    [SerializeField]
    public Transform m_actorInfoShowContent;
    public ActorInfo m_actorInfo;
    [SerializeField]
    private Text m_submitText;
    void Awake()
    {
        AppFacade.instance.RegisterMediator(new GiveLikeViewMediator(this));
        AppFacade.instance.RegisterMediator(new GiveLikeMediator(this));
        m_continue.onClick.AddListener(GoOnAndContinue);
    }
    public override void Show()
    {
        base.Show();
        GetGiveLikeInfo();
    }
    public void ContinueShow()
    {
        if (m_continue.gameObject.activeSelf == false)
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
    public void ReceiveActorID(string _actorId)
    {
        GetActorID(_actorId);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class ActorInfo : MonoBehaviour
{
    [SerializeField]
    private Button m_actorInfoButton;
    [SerializeField]
    private Image m_giveLikeImage;
    [SerializeField]
    private Image m_actorHeadIconImage;
    [SerializeField]
    private Text m_actorNameText;
    private bool isSelect = false;
    public GiveLikeView m_giveLikeView;
    private string m_actorId;
    void Start()
    {
        m_actorInfoButton.onClick.AddListener(OnClickChoiceThisActor);
    }
    public void Init(GiveLikeView _view)
    {
        m_giveLikeView = _view;
    }
    private void OnClickChoiceThisActor()
    {
        isSelect = !isSelect;
        if (isSelect==true)
        {
            m_giveLikeImage.gameObject.SetActive(true);
            m_giveLikeView.ReceiveActorID(m_actorId);
        }
    }
    public void ShowName(ActorDetailsModel _actorInfoList)
    {
        string avatarName = _actorInfoList.avatar+ " (UnityEngine.Sprite)";
        m_actorNameText.text = _actorInfoList.nickName;
        m_actorId = _actorInfoList.id;
        Addressables.LoadAssetAsync<Sprite>(avatarName).Completed += OnImageInstantiated;
    }
    private void OnImageInstantiated(AsyncOperationHandle<Sprite> _obj)
    {
        m_actorHeadIconImage.sprite = _obj.Result;
    }
  
}

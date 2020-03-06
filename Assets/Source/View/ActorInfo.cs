using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActorInfo : MonoBehaviour
{
    [SerializeField]
    private Button m_actorInfoButton;
    [SerializeField]
    private Image m_giveLikeImage;
    public Image m_actorHeadIconImage;
    public Text m_actorNameText;
    private bool isSelect = false;
    void Start()
    {
        m_actorInfoButton.onClick.AddListener(OnClickChoiceThisActor);
    }
    private void OnClickChoiceThisActor()
    {
        isSelect = !isSelect;
        if (isSelect==true)
        {
            m_giveLikeImage.gameObject.SetActive(true);
        }
        else
        {
            m_giveLikeImage.gameObject.SetActive(false);
        }
    }
    public void Show(ActorDetailsModel _actorInfoList)
    {
        string nickName = _actorInfoList.avatar;
        m_actorHeadIconImage.sprite = Resources.Load<Sprite>("Textures/Images/Portraits/"+nickName);
        m_actorNameText.text = _actorInfoList.nickName;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopEmail : MonoBehaviour
{
    public Text m_wikiGroupName;
    public Image m_wikiGroupImage;
    public Text m_wikiGroupDes;

    public Image m_wikiRecordImage;
    public Text m_wikiRecordName;

    [SerializeField]
    private Button m_closeButton;
    private void Start()
    {
        m_closeButton.onClick.AddListener(ClosePopMail);
    }
    private void ClosePopMail()
    {
        transform.gameObject.SetActive(false);
    }
}

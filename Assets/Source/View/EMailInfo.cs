using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EMailInfo : MonoBehaviour
{
    [SerializeField]
    public Button m_eMailButton;
    [SerializeField]
    private PopEmail m_EMailPop;
    [SerializeField]
    public string m_wiki_Group_Name;
    public EMailView m_mMailView; 
    void Start()
    {
        m_eMailButton.onClick.AddListener(delegate () { OpenTheEMail(m_wiki_Group_Name); });
    }
    private void OpenTheEMail(string _wikiGroupName)
    {
        m_mMailView.GetWikiGroupName(_wikiGroupName);
        if (m_EMailPop.gameObject.activeSelf==false)
        {
            m_EMailPop.gameObject.SetActive(true);
        }
    }
   
}

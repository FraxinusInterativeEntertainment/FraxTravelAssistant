using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WikiRecordInfo : MonoBehaviour
{
    [SerializeField]
    private Button m_wikiRecordButton;
    [SerializeField]
    private Text m_wikiRecordText;
    public PersonLocationInformationView personLocationInforView;
    private void Start()
    {
        m_wikiRecordButton.onClick.AddListener(delegate () { SendWikiRecordName(m_wikiRecordText.text); });
    }
    public void Init(PersonLocationInformationView _view)
    {
        personLocationInforView = _view;
    }
    private void SendWikiRecordName(string _wikiRecordName)
    {
        personLocationInforView.GetWikiRecordName(_wikiRecordName);
    }
}

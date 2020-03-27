using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class PersonLocationInformationMediator : Mediator, IMediator
{
    public const string NAME = "PersonLocationInformationMediator";

    private BackGroundStoryProxy backGroundStoryProxy;
    private PersonLocationInformationView m_infoView { get { return m_viewComponent as PersonLocationInformationView; } }
    public PersonLocationInformationMediator(PersonLocationInformationView _view) : base(NAME, _view)
    {
        backGroundStoryProxy = Facade.RetrieveProxy(BackGroundStoryProxy.NAME) as BackGroundStoryProxy;
        m_infoView.GetWikiRecordNumber += TryGetWikiRecordNumber;
        m_infoView.OpenWikiRecord += TryGetWikiRecordDes;
    }
    public override IList<string> ListNotificationInterests()
    {
        return new List<string>()
        {
           Const.Notification.BACK_WIKI_RECORD_STORY
        };
    }
    public override void HandleNotification(INotification _notification)
    {
        string name = _notification.Name;
        object vo = _notification.Body;
        switch (name)
        {
            case Const.Notification.BACK_WIKI_RECORD_STORY:
                m_infoView.ShowWikiRecordDes(vo);
                InstateWikiRecordImage(vo);
                break;
        }
    }
    private void TryGetWikiRecordNumber()
    {
        int wikiRecords = backGroundStoryProxy.wikiGroupInfo.wiki_records.Count;
        for (int i = 0; i < wikiRecords; i++)
        {
            Addressables.InstantiateAsync("WikiRecordImage").Completed += OnWikiRecordInstantiated;
        }
    }
    private void TryGetWikiRecordDes(string _wikiName)
    {
        SendNotification(Const.Notification.GET_WIKI_RECORD_STORY, _wikiName);
    }
    private void OnWikiRecordInstantiated(AsyncOperationHandle<GameObject> _obj)
    {
        WikiRecordInfo wikiRecordInfo = _obj.Result.GetComponent<WikiRecordInfo>();
        wikiRecordInfo.transform.SetParent(m_infoView.m_cards);
        wikiRecordInfo.Init(m_infoView);
        SetWikiRecordImageText();
    }
    string wikiName;
    private void SetWikiRecordImageText()
    {
        for (int i = 0; i < backGroundStoryProxy.wikiGroupInfo.wiki_records.Count; i++)
        {
            wikiName = backGroundStoryProxy.wikiGroupInfo.wiki_records[i].ToString();
            Addressables.LoadAssetAsync<Sprite>(wikiName).Completed += OnImageInstantiated;
        } 
    }
    private void OnImageInstantiated(AsyncOperationHandle<Sprite> _obj)
    {
        for (int i = 0; i < m_infoView.m_cards.childCount; i++)
        {
            m_infoView.m_cards.GetChild(i).GetComponent<Image>().sprite = _obj.Result;
            m_infoView.m_cards.GetChild(i).GetChild(0).GetComponent<Text>().text = wikiName;
        }
    }
    private void InstateWikiRecordImage(object _obj)
    {
        WikiRecord wikiRecord = _obj as WikiRecord;
        string recordImage = wikiRecord.Image;
        Addressables.LoadAssetAsync<Sprite>(recordImage).Completed += OnRecordImageInstantiated;
    }
    private void OnRecordImageInstantiated(AsyncOperationHandle<Sprite> _obj)
    {
        Sprite sprite = _obj.Result;
        m_infoView.ShowImage(sprite);
    }
}

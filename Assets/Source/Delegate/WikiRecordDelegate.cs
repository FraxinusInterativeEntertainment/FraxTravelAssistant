using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WikiRecordDelegate
{
    private IResponder m_responder;
    private HttpService m_httpService;
    public WikiRecordDelegate(IResponder _responder, string _wikiRecordName)
    {
        m_responder = _responder;
        m_httpService = new HttpService(Const.Url.GET_WIKI_RECORD_INFO + "?wiki_name=" + _wikiRecordName, HttpRequestType.Get);
    }
    public void TryGetWikiRecordInfo()
    {
        m_httpService.SendRequest<WikiRecordResponse>(WikiRecordInfoCallback);
    }
    private void WikiRecordInfoCallback(WikiRecordResponse _httpResponse)
    {
        if (_httpResponse.err_code == 0)
        {
            m_responder.OnResult(_httpResponse.err_msg);
        }
        else
        {
            Debug.Log("_httpResponse.err_code" + _httpResponse.err_msg);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMailDelegate
{
    private IResponder m_responder;
    private HttpService m_httpService;
    public EMailDelegate(IResponder _responder,string _wikiGroupName)
    {
        m_responder = _responder;
        m_httpService = new HttpService(Const.Url.GET_WIKI_GROUP_INFO + "?" + _wikiGroupName, HttpRequestType.Get);
    }
    public void GetWikiGroupInfo()
    {
        m_httpService.SendRequest<HttpResponse>(WikiGroupInfoCallback);
    }
    private void WikiGroupInfoCallback(HttpResponse _httpResponse)
    {
        if (_httpResponse.err_code == 0)
        {
            Debug.Log("_httpResponse.err_code == 0");
            m_responder.OnFault(_httpResponse.err_msg);
        }
        else
        {
            Debug.Log("_httpResponse==" + _httpResponse.err_msg);
            m_responder.OnResult(_httpResponse.err_msg);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintInfoDelegate
{
    private IResponder m_responder;
    private HttpService m_httpService;
    public HintInfoDelegate(IResponder _responder,string _wikiGroupID)
    {
        m_responder = _responder;
        m_httpService = new HttpService(Const.Url.GET_HINT + "?wiki_group_name=" + _wikiGroupID, HttpRequestType.Get);
    }
    public void GetHintInfo()
    {
        m_httpService.SendRequest<WikiGroupResponse>(HintInfoCallback);
    }
    private void HintInfoCallback(WikiGroupResponse _httpResponse)
    {
        if (_httpResponse.err_code == 0)
        {
            m_responder.OnResult(_httpResponse.wiki_group_info);
        }
      
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundStoryDelegate
{
    private IResponder m_responder;
    private HttpService m_httpService;
    public BackGroundStoryDelegate(IResponder _responder, string _wikiName)
    {
        m_responder = _responder;
        m_httpService = new HttpService(Const.Url.GET_WIKI_GROUP_INFO + "?wiki_group_name=" + _wikiName, HttpRequestType.Get);
    }

    public void GetBackGroundStory()
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

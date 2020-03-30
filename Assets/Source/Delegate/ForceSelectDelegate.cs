using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceSelectDelegate
{
    private IResponder m_responder;
    private HttpService m_httpService;
    public const string LOCATION_WIKI_TYPE = "?wiki_type=2";
    public ForceSelectDelegate(IResponder _responder)
    {
        m_responder = _responder;
        m_httpService = new HttpService(Const.Url.GET_LOCKED_WIKI_GROUP_INFO + LOCATION_WIKI_TYPE, HttpRequestType.Get);
    }
    public void GetLockedWikiGroupInfo()
    {
        m_httpService.SendRequest<AvailableWikiGroupResponse>(AvailableWikiGroupCallBack);
    }
    private void AvailableWikiGroupCallBack(AvailableWikiGroupResponse _httpResponse)
    {
        if (_httpResponse.err_code == 0)
        {
            m_responder.OnResult(_httpResponse.wiki_group_info);
        }
        else
        {
            Debug.Log("_httpResponse.err_code==1");
        }
    }
}

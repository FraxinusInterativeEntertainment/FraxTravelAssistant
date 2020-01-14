using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfoDelegate
{
    private IResponder m_responder;
    private HttpService m_httpService;

    public UserInfoDelegate(IResponder _responder)
    {
        m_responder = _responder;
        m_httpService = new HttpService(Const.Url.GET_USERINFO, HttpRequestType.Get);
    }
    public void GetUserInfo()
    {
        m_httpService.SendRequest<HttpResponse>(UserInfoCallback);
    }
    private void UserInfoCallback(HttpResponse _httpResponse)
    {
        if (_httpResponse.err_code!=0)
        {
            m_responder.OnFault(_httpResponse.err_msg);
        }
        else
        {
            m_responder.OnResult(_httpResponse.err_msg);
        }
    }
}


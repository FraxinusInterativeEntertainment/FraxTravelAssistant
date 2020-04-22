using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditUserInfoDelegate
{
    private IResponder m_responder;
    private HttpService m_httpService;
    public EditUserInfoDelegate(IResponder _responder)
    {
        m_responder = _responder;
        m_httpService = new HttpService(Const.Url.GET_USERINFO, HttpRequestType.Get);
    }
    public void GetUserInfo()
    {
        m_httpService.SendRequest<EditUserInfoResponse>(HintInfoCallback);
    }
    private void HintInfoCallback(EditUserInfoResponse _httpResponse)
    {
        if (_httpResponse.err_code == 0)
        {
            m_responder.OnResult(_httpResponse.user_extra_info);
        }
        else
        {
            Debug.Log("更该失败"+ _httpResponse.err_msg);
            m_responder.OnResult(_httpResponse.err_msg);
        }
    }
}

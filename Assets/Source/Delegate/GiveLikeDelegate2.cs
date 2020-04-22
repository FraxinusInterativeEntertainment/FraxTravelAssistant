using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveLikeDelegate2 
{
    private IResponder m_responder;
    private HttpService m_httpService;
    public GiveLikeDelegate2(IResponder _responder,string _userID)
    {
        WWWForm form = new WWWForm();
        form.AddField("assessed_user_id", _userID);
        form.AddField("thumb_up", 1);
        m_responder = _responder;
        m_httpService = new HttpService(Const.Url.ASSESSED_USER_ID, HttpRequestType.Post,form);
    }
    public void EvaluateUser()
    {
        m_httpService.SendRequest<HttpResponse>(EvaluateUserCallBack);
    }
    private void EvaluateUserCallBack(HttpResponse _httpResponse)
    {
        if (_httpResponse.err_code == 0)
        {
            m_responder.OnResult(_httpResponse.err_msg);
        }
        else
        {
            m_responder.OnFault(_httpResponse.err_msg);
        }
    }
}

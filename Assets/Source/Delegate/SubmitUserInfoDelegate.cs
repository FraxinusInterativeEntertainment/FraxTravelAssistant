using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitUserInfoDelegate
{
    private IResponder m_responder;
    private HttpService m_httpService;

    public SubmitUserInfoDelegate(IResponder _responder,SubmitUserInfoVO _submitUserInfoVO)
    {
        WWWForm form = new WWWForm();
        form.AddField("avatar", _submitUserInfoVO.UserInfo_HeadIcon);
        form.AddField("nickname", _submitUserInfoVO.UserInfo_NickName);
        form.AddField("sex", _submitUserInfoVO.UserInfo_Sex);
        form.AddField("birthday", _submitUserInfoVO.UserInfo_Born);

        m_responder = _responder;
        m_httpService = new HttpService(Const.Url.POST_SUBMIT_USERINFO, HttpRequestType.Post, form);
    }
    public void SubmitUserInfoService()
    {
        m_httpService.SendRequest<HttpResponse>(SubmitUserInfoCallBack);
    }
    private void SubmitUserInfoCallBack(HttpResponse _httpResponse)
    {
        if (_httpResponse.err_code==0)
        {
            m_responder.OnResult(_httpResponse.err_code);
        }
        else
        {
            m_responder.OnFault(_httpResponse.err_msg);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandIdLoginDelegate
{
    private IResponder m_responder;
    private HttpService m_httpService;

    public BandIdLoginDelegate(IResponder _responder, LoginVO _loginVO)
    {
        WWWForm form = new WWWForm();
        form.AddField("band_id", _loginVO.WristBandID);
        form.AddField("device_id", _loginVO.UWBTagID);

        m_responder = _responder;
        m_httpService = new HttpService(Const.Url.POST_WRISTBAND_ID, HttpRequestType.Post, form);
    }

    public void LoginService()
    {
        m_httpService.SendRequest<HttpResponse>(LoginCallback);
    }

    private void LoginCallback(HttpResponse _httpResponse)
    {
        if (_httpResponse.err_code == 0)
        {
            m_responder.OnResult(_httpResponse.err_code);
        }
        else
        {
            m_responder.OnFault(_httpResponse.err_msg);
        }
    }
}

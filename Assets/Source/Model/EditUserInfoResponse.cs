using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditUserInfoResponse : HttpResponse
{
    public UserExtraInfo user_extra_info { get; set; }
    public EditUserInfoResponse(int _errCode, string _errMsg) : base(_errCode, _errMsg)
    {
        this.err_code = _errCode;
        this.err_msg = _errMsg;
    }
}
public class UserExtraInfo
{
    public string avatar { get; set; }
    public string nickname { get; set; }
    public string sex { get; set; }
    public string birthday { get; set; }
    public bool has_info_record { get; set; }
}

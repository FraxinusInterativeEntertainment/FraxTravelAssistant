using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitUserInfoVO
{
    public string UserInfo_HeadIcon { get; set; }
    public string UserInfo_NickName { get; set; }
    public int UserInfo_Sex { get; set; }
    public string UserInfo_Born { get; set; }
    public SubmitUserInfoVO(string _userInfo_HeadIcon,string _userInfo_NickName,int _userInfo_Sex,string _userInfo_Born)
    {
        UserInfo_HeadIcon = _userInfo_HeadIcon;
        UserInfo_NickName = _userInfo_NickName;
        UserInfo_Sex = _userInfo_Sex;
        UserInfo_Born = _userInfo_Born;
    }

    public SubmitUserInfoVO()
    {
    }
}

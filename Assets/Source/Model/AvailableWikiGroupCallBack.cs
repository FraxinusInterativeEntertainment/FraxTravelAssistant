using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailableWikiGroupResponse : HttpResponse
{
    public AvailableWikiGroupInfo[] wiki_group_info { get; set; }
    public AvailableWikiGroupResponse(int _errCode, string _errMsg) : base(_errCode, _errMsg)
    {
        this.err_code = _errCode;
        this.err_msg = _errMsg;
    }

}
public class AvailableWikiGroupInfo
{
    public string name { get; set; }
    public string title { get; set; }
    public bool unlocked { get; set; }
   
}



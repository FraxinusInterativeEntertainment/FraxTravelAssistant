using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WikiGroupResponse : HttpResponse
{
    public WikiGroupInfo wiki_group_info { get;set;}

    public WikiGroupResponse(int _errCode,string _errMsg):base(_errCode, _errMsg)
    {
        this.err_code = _errCode;
        this.err_msg = _errMsg;
    }
}
public class WikiGroupInfo
{
    public string ID { get; set; }
    public string Title { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    public List<string> wiki_records { get; set; }
}


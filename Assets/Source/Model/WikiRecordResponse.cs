using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WikiRecordResponse : HttpResponse
{
    public WikiRecord wiki_info { get; set; }

    public WikiRecordResponse(int _errCode, string _errMsg) : base(_errCode, _errMsg)
    {
        this.err_code = _errCode;
        this.err_msg = _errMsg;
    }
}
public class WikiRecord
{
    public string ID { get; set; }
    public string Title { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorDetailsListResponse : HttpResponse
{
    public List<ActorDetailsModel> assess_user_list;
    public ActorDetailsListResponse(int _err_code,string _err_msg) : base(_err_code,_err_msg)
    {
        this.err_code = _err_code;
        this.err_msg = _err_msg;
    }

}

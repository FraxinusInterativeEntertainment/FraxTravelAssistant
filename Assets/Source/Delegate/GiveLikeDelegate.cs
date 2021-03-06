﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveLikeDelegate
{
    private IResponder m_responder;
    private HttpService m_httpService;
    public GiveLikeDelegate(IResponder _responder)
    {
        m_responder = _responder;
        m_httpService = new HttpService(Const.Url.GET_GIVELIKE, HttpRequestType.Get);

    }
    public void GetActorInfo()
    {
        ActorDetailsModel actorDetailsModel1 = new ActorDetailsModel("1","xiaoLiu", "portrait_1");
        ActorDetailsModel actorDetailsModel2 = new ActorDetailsModel("2", "zhangjie", "portrait_2");
        ActorDetailsModel actorDetailsModel3 = new ActorDetailsModel("3", "peter", "portrait_3");
        ActorDetailsModel actorDetailsModel4 = new ActorDetailsModel("4", "Mayun", "portrait_4");
        ActorDetailsModel actorDetailsModel5 = new ActorDetailsModel("5", "MaHuaTeng", "portrait_5");
        List<ActorDetailsModel> actorDetailsModels = new List<ActorDetailsModel>();
        actorDetailsModels.Add(actorDetailsModel1);
        actorDetailsModels.Add(actorDetailsModel2);
        actorDetailsModels.Add(actorDetailsModel3);
        actorDetailsModels.Add(actorDetailsModel4);
        actorDetailsModels.Add(actorDetailsModel5);
        m_responder.OnResult(actorDetailsModels);
    }
    private void ActorInfoCallBack(ActorDetailsListResponse _httpResponse)
    {
        if (_httpResponse.err_code != 0)
        {
            m_responder.OnFault(_httpResponse.err_msg);
        }
        else
        {
            m_responder.OnResult(_httpResponse.assess_user_list);
        }
    }
}


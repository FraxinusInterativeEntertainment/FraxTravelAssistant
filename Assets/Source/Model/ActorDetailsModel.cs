using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorDetailsModel
{
   public string  id { get; set; }
    public string nickName { get; set; }
    public string avatar { get; set; }
    public ActorDetailsModel(string _id,string _nickName,string _avatar)
    {
        id = _id;
        nickName = _nickName;
        avatar = _avatar;
    }

}

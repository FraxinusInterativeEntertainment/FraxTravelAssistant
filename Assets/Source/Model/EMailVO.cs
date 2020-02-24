using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMailVO : ServerMessage
{
    public string MsgType { get; set; }
    public string[]msgContent { get; set; }
    public EMailVO(string _msgType) : base(_msgType)
    {
        this.MsgType = _msgType;
    }
   
}

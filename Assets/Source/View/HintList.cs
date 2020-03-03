using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintList : ServerMessage
{
    public string MsgType { get; set; }
    public string[] msgContent { get; set; }
    public HintList(string _msgType) : base(_msgType)
    {
        this.MsgType = _msgType;
    }
}

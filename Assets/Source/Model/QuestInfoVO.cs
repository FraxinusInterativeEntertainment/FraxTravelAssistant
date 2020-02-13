using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestInfoVO : ServerMessage
{
    public string MsgType { get; set; }
    public MsgContent msgContent { get; set; }
   
    public QuestInfoVO(string _msgType) : base(_msgType)
    {
        this.MsgType = _msgType;
    }
}
public class MsgContent
{
    public string node_name { get; set; }
    public string desc { get; set; }
    public string location { get; set; }
    public string character { get; set; }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintsName 
{
    private static readonly HintsName _instance = new HintsName();
    public static HintsName Instance
    {
        get
        {
            return _instance;
        }
    }
    private HintsName() { }
    public string hintName { get; set; }

}

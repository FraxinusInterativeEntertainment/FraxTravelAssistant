﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class QuestInfoCommand : SimpleCommand
{

    public override void Execute(INotification _notification)
    {
        object obj = _notification.Body;
        string name = _notification.Name;
        switch (name)
        {
           
           
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMCommondAttribute : Attribute
{
    public string cmd;
    public int paramNum;
    public string usage;

    public GMCommondAttribute(string cmd, int paramNum, string usage)
    {
        this.cmd = cmd;
        this.paramNum = paramNum;
        this.usage = usage;
    }
}

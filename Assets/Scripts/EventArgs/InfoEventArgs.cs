using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoEventArgs<T> : EventArgs
{

    private T info; 

    public T Info
    {
        get { return info; }
        set { info = value; }
    }

    public InfoEventArgs()
    {
        info = default(T);
    }

    public InfoEventArgs(T t)
    {
        info = t;
    }
}

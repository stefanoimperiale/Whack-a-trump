using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChangeEventArgs : EventArgs
{
    public bool isActive;

    public ButtonChangeEventArgs(bool isActive)
    {
        this.isActive = isActive;
    }
}

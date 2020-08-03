using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class HelpMenuButton : MenuButton
{
    public void OfficialWebsite()
    {
        Process.Start("https://www.arduino.cc/");
    }
}

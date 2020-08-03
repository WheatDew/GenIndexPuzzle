using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class BuildingMenuButton : MenuButton
{
    public InputField inputBox;
    public InputField outputBox;


    public void BuildingCode()
    {
        try
        {
            Process p = new Process();

            p.StartInfo.StandardErrorEncoding = Encoding.UTF8;

            p.StartInfo.FileName = "cmd.exe";

            p.StartInfo.UseShellExecute = false;

            p.StartInfo.RedirectStandardInput = true;

            p.StartInfo.RedirectStandardOutput = false;

            p.StartInfo.RedirectStandardError = true;

            p.StartInfo.CreateNoWindow = true;

            p.Start();

            p.StandardInput.WriteLine("arduino_debug --verify " + MenuButton.path );

            p.StandardInput.WriteLine("exit");

            p.StandardInput.AutoFlush = true;

            p.StandardInput.Close();

            string strError = p.StandardError.ReadToEnd();

            outputBox.text = strError;

            p.WaitForExit();
            p.Close();

            UnityEngine.Debug.Log("编译成功");
        }
        catch (Exception ex)
        {
            UnityEngine.Debug.Log(ex.ToString());
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingPageModelChildren : MonoBehaviour
{
    public GameObject mainProgram;
    public GameObject serialPrint;
    public GameObject delay;

    public Transform originParent;

    public CodeClip[] codeClips;

    public void CreateMainProgram()
    {
        GameObject obj = Instantiate(mainProgram,originParent);
        codeClips = FindObjectsOfType<CodeClip>();
    }

    public void CreateSerialPrint()
    {
        GameObject obj = Instantiate(serialPrint, originParent);
        codeClips = FindObjectsOfType<CodeClip>();
    }

    public void CreateDelay()
    {
        GameObject obj = Instantiate(delay, originParent);
        codeClips = FindObjectsOfType<CodeClip>();
    }
}

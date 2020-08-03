using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class MenuButton : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public GameObject Menu;

    private Button selfButton;

    private bool isPressed=false;

    public static string path="Standard.ino";

    void Start()
    {
        selfButton = GetComponent<Button>();

        selfButton.onClick.AddListener(SetPressed);

    }

    public void SetPressed()
    {
        if (isPressed)
        {
            HideMenu();
            isPressed = false;
        }

        else
        {
            DisplayMenu();
            isPressed = true;
        }

    }

    public void DisplayMenu()
    {
        Menu.SetActive(true);
    }

    public void HideMenu()
    {
        Menu.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(isPressed)
        DisplayMenu();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isPressed)
        {
            HideMenu();
            isPressed = false;
        }

    }


    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintingButton : MonoBehaviour
{

    public string modeString1="拼图模式";
    public string modeString2="代码模式";

    public GameObject modePage1;
    public GameObject modePage2;
    public GameObject modePage1Children;

    private Text buttonText;
    private Button button;

    public InputField codingBox;

    void Start()
    {
        modePage1.SetActive(true);
        modePage1Children.SetActive(true);
        modePage2.SetActive(false);

        buttonText = transform.GetChild(0).GetComponent<Text>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SwitchButton);
    }

    public void SwitchButton()
    {
        if (buttonText.text == modeString1)
        {
            buttonText.text = modeString2;
            modePage1.SetActive(false);
            modePage1Children.SetActive(false);
            modePage2.SetActive(true);
        }
        else
        {
            buttonText.text = modeString1;
            modePage1.SetActive(true);
            modePage1Children.SetActive(true);
            modePage2.SetActive(false);
            DownLoadCode();
        }
    }

    //下载代码
    public void DownLoadCode()
    {
        foreach(var item in FindObjectsOfType<CodeClip>())
        {
            if (item.layerClass == 1)
                codingBox.text = item.GetCode();
        }
    }
}

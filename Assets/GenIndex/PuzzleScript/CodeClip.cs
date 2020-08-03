using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeClip : MonoBehaviour
{

    public Transform elementMiddle;
    public Transform elementTop;
    public Transform elementBottom;

    public TextMesh textMesh;

    public int layerClass = 0;

    public int childClipCount = 2;

    public bool isMove=true;

    public CodeClip clipParent;

    public List<CodeClip> clipChildren = new List<CodeClip>();

    private PaintingPageModelChildren paintingPageModelChildren;

    public string codeAbove;
    public string codeBelow;

    private bool isMoving=false;

    private void Start()
    {
        InitializeCodingClips();
        MiddleStreth(0,0);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isMove)
        {
            ClipClickStart();
        }

        if (Input.GetMouseButtonUp(0))
            ClipClickEnd();

        if (isMoving)
            ClipMove();

        VerifyCodingClipsDistence();
    }

    public void InitializeCodingClips()
    {
        codeAbove= codeAbove.Replace('@', '\n');
        codeBelow= codeBelow.Replace('@', '\n');
        paintingPageModelChildren = FindObjectOfType<PaintingPageModelChildren>();
    }

    //验证片段之间的距离
    public void VerifyCodingClipsDistence()
    {
        foreach(var item in paintingPageModelChildren.codeClips)
        {
            if (!IsChild(item)&&item.clipParent==null&&item.layerClass>layerClass&&Vector3.Distance(transform.position, item.transform.position) < 0.5f)
            {
                AddChildCodingClip(item);
                item.clipParent = this;
                clipChildren.Add(item);
            }
        }
    }

    //递归判断父节点嵌套
    public bool IsChild(CodeClip target)
    {
        if (target.clipParent != null )
        {
            if (target.clipParent == this)
                return true;
            else
               return  IsChild(target.clipParent);
        }
        return false;
    }

    public void ClipClickStart()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit2;
        Physics.Raycast(ray, out hit2);

        if (elementTop && elementBottom)
        {
            if (hit2.collider.transform == elementMiddle || hit2.collider.transform == elementTop || hit2.collider.transform == elementBottom)
            {
                isMoving = true;
            }
        }
        else if (elementMiddle)
        {
            if (hit2.collider.transform == elementMiddle)
            {
                isMoving = true;
            }
        }
    }

    public void ClipClickEnd()
    {
        isMoving = false;
    }

    public void ClipMove()
    {
        if (isMoving)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, 100f, 1 << 8);
            transform.position = new Vector3(hit.point.x, 0, hit.point.z);
        }
    }

    public void MiddleStreth(float value,int countGain)
    {
        elementMiddle.localScale = new Vector3(elementMiddle.localScale.x, elementMiddle.localScale.y, value);
        elementMiddle.localPosition = new Vector3(elementMiddle.localPosition.x, elementMiddle.localPosition.y, elementMiddle.localScale.z * 5f);
        if (elementTop)
            elementTop.localPosition = new Vector3(elementTop.localPosition.x, elementTop.localPosition.y,
                elementMiddle.localPosition.z - elementMiddle.localScale.z * 5 - elementTop.localScale.z * 5);
        if (elementBottom)
            elementBottom.localPosition = new Vector3(elementBottom.localPosition.x, elementBottom.localPosition.y,
                elementMiddle.localPosition.z + elementMiddle.localScale.z * 5 + elementBottom.localScale.z * 5);
        if (textMesh)
            textMesh.transform.localPosition = new Vector3(textMesh.transform.localPosition.x, textMesh.transform.localPosition.y, elementMiddle.localPosition.z);

        if (clipParent != null)
        {
            clipParent.childClipCount += countGain;
            clipParent.MiddleStreth((clipParent.childClipCount-2) * 0.01f,countGain);
        }
    }

    public void AddChildCodingClip(CodeClip child)
    {
        childClipCount += child.childClipCount;
        child.transform.parent = transform;
        child.transform.localPosition = new Vector3(elementMiddle.localPosition.x + 0.4f, child.transform.localPosition.y, (childClipCount - 3) * 0.1f);
        MiddleStreth((childClipCount - 2) * 0.01f, child.childClipCount);
        child.isMove = false;
    }

    public string GetCode()
    {
        string coding="";

        coding += codeAbove;

        foreach(var item in clipChildren)
        {
            coding += item.GetCode();
        }

        coding += codeBelow;

        return coding;
    }
}

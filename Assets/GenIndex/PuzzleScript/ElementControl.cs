using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementControl : MonoBehaviour
{
    public Transform elementMiddle;
    public Transform elementTop;
    public Transform elementBottom;

    public int childrenCount=0;

    private ElementSystem elementSystem;

    private List<Transform> childrenElement = new List<Transform>();

    private void Start()
    {
        elementSystem = FindObjectOfType<ElementSystem>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray ,out hit,100f,1<<8);
            RaycastHit hit2;
            Physics.Raycast(ray, out hit2);
            //
            if (hit2.collider.transform == elementMiddle || hit2.collider.transform == elementTop || hit2.collider.transform == elementBottom)
            {
                transform.position = new Vector3(hit.point.x, 0, hit.point.z);
            }
            
            Transform elementChild;
            if (elementSystem.IsChildClosed(transform,out elementChild))
            {
                childrenElement.Add(elementChild);
                childrenCount++;
                SetChildElementPosition();
                elementChild.parent = transform;
            }
        }

        MiddleStreth(0.04f * childrenCount);
    }

    //设置子模块位置
    public void SetChildElementPosition()
    {
        //switch (childrenCount)
        //{
        //    case 1:
        //        childrenElement[0].transform.position = new Vector3(
        //            transform.position.x + transform.GetChild(0).localScale.x * 5f + childrenElement[0].GetChild(0).localScale.x * 5f,
        //            0, transform.position.z);
        //        break;
        //    case 2:
        //        childrenElement[0].transform.position = new Vector3(
        //            transform.position.x + transform.GetChild(0).localScale.x * 5f + childrenElement[0].GetChild(0).localScale.x * 5f,
        //            0, transform.position.z + childrenElement[0].GetChild(0).localScale.z * 5f);

        //        childrenElement[1].transform.position = new Vector3(
        //            transform.position.x + transform.GetChild(0).localScale.x * 5f + childrenElement[1].GetChild(0).localScale.x * 5f,
        //            0, transform.position.z - childrenElement[1].GetChild(0).localScale.z * 5f);
        //        break;
        //    case 3:
        //        childrenElement[0].transform.position = new Vector3(
        //            transform.position.x + transform.GetChild(0).localScale.x * 5f + childrenElement[0].GetChild(0).localScale.x * 5f,
        //            0, transform.position.z + childrenElement[0].GetChild(0).localScale.z * 5f+ childrenElement[1].GetChild(0).localScale.z*5f);

        //        childrenElement[1].transform.position = new Vector3(
        //            transform.position.x + transform.GetChild(0).localScale.x * 5f + childrenElement[1].GetChild(0).localScale.x * 5f,
        //            0, transform.position.z);
        //        childrenElement[2].transform.position = new Vector3(
        //            transform.position.x + transform.GetChild(0).localScale.x * 5f + childrenElement[2].GetChild(0).localScale.x * 5f,
        //            0, transform.position.z - childrenElement[1].GetChild(0).localScale.z * 5f - childrenElement[2].GetChild(0).localScale.z * 5f);
        //        break;
        //    case 4:
        //        childrenElement[0].transform.position = new Vector3(
        //            transform.position.x + transform.GetChild(0).localScale.x * 5f + childrenElement[0].GetChild(0).localScale.x * 5f,
        //            0, transform.position.z + childrenElement[0].GetChild(0).localScale.z * 5f + childrenElement[1].GetChild(0).localScale.z*10);
        //        childrenElement[1].transform.position = new Vector3(
        //            transform.position.x + transform.GetChild(0).localScale.x * 5f + childrenElement[0].GetChild(0).localScale.x * 5f,
        //            0, transform.position.z + childrenElement[1].GetChild(0).localScale.z * 5f);
        //        childrenElement[2].transform.position = new Vector3(
        //            transform.position.x + transform.GetChild(0).localScale.x * 5f + childrenElement[0].GetChild(0).localScale.x * 5f,
        //            0, transform.position.z - childrenElement[2].GetChild(0).localScale.z * 5f);
        //        childrenElement[3].transform.position = new Vector3(
        //            transform.position.x + transform.GetChild(0).localScale.x * 5f + childrenElement[0].GetChild(0).localScale.x * 5f,
        //            0, transform.position.z - childrenElement[3].GetChild(0).localScale.z * 5f - childrenElement[3].GetChild(0).localScale.z*10);
        //        break;
        //    case 5:
        //        childrenElement[0].transform.position = new Vector3(
        //            transform.position.x + transform.GetChild(0).localScale.x * 5f + childrenElement[0].GetChild(0).localScale.x * 5f,
        //            0, transform.position.z + childrenElement[0].GetChild(0).localScale.z * 5f
        //            + childrenElement[1].GetChild(0).localScale.z*10f+childrenElement[2].GetChild(0).localScale.z*5f);
        //        childrenElement[1].transform.position = new Vector3(
        //            transform.position.x + transform.GetChild(0).localScale.x * 5f + childrenElement[1].GetChild(0).localScale.x * 5f,
        //            0, transform.position.z + childrenElement[1].GetChild(0).localScale.z * 5f + childrenElement[2].GetChild(0).localScale.z * 5f);
        //        childrenElement[2].transform.position = new Vector3(
        //            transform.position.x + transform.GetChild(0).localScale.x * 5f + childrenElement[2].GetChild(0).localScale.x * 5f,
        //            0, transform.position.z );
        //        childrenElement[1].transform.position = new Vector3(
        //            transform.position.x + transform.GetChild(0).localScale.x * 5f + childrenElement[1].GetChild(0).localScale.x * 5f,
        //            0, transform.position.z - childrenElement[1].GetChild(0).localScale.z * 5f - childrenElement[2].GetChild(0).localScale.z * 5f);
        //        childrenElement[0].transform.position = new Vector3(
        //            transform.position.x + transform.GetChild(0).localScale.x * 5f + childrenElement[0].GetChild(0).localScale.x * 5f,
        //            0, transform.position.z - childrenElement[0].GetChild(0).localScale.z * 5f
        //            - childrenElement[1].GetChild(0).localScale.z * 10f - childrenElement[2].GetChild(0).localScale.z * 5f);
        //        break;
        //}

        float transformLength=0;

        for(int i = 0; i < childrenElement.Count; i++)
        {
            transformLength += childrenElement[i].localScale.z;
        }

        for(int i = 0; i < childrenElement.Count; i++)
        {
            float length = 0;
            for(int j = 0; j < i; j++)
            {
                length += childrenElement[j].localScale.z*10f;
            }

            length += childrenElement[i].localScale.z * 5f;

            childrenElement[i].position = new Vector3(0, 0, transform.position.z + transformLength * 0.5f-length);
        }
    }

    //脚本动画
    public void MiddleStrethAnimation(int value)
    {
        
    }

    public void MiddleStreth(float value)
    {
        elementMiddle.localScale = new Vector3(elementMiddle.localScale.x, elementMiddle.localScale.y, value);
        if (elementTop)
            elementTop.position = new Vector3(elementTop.position.x, elementTop.position.y,
                elementMiddle.position.z - elementMiddle.localScale.z * 5 - elementTop.localScale.z * 5);
        if (elementBottom)
            elementBottom.position = new Vector3(elementBottom.position.x, elementBottom.position.y,
                elementMiddle.position.z + elementMiddle.localScale.z * 5 + elementBottom.localScale.z * 5);
    }

}

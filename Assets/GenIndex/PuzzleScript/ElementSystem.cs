using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSystem : MonoBehaviour
{

    public HashSet<Transform> elementList=new HashSet<Transform>();
    public HashSet<Transform> childElementList=new HashSet<Transform>();

    public GameObject element1;
    public GameObject element2;

    private void Start()
    {
        foreach(var item in FindObjectsOfType<ChildElementControl>())
        {
            childElementList.Add(item.transform);
        }
    }

    public void CreateElement1()
    {
        GameObject obj = Instantiate(element1);
    }

    public void CreateElement2()
    {
        GameObject obj = Instantiate(element2);
    }

    public bool IsChildClosed(Transform e1,out Transform e2)
    {
        bool isClosed = false;

        e2 = null;

        foreach(var item in childElementList)
        {
            if (Vector3.Distance(item.position, e1.position) < 0.7f&&e1.position.x-item.position.x<0.7)
            {
                isClosed = true;
                e2 = item;
            }
        }

        if (e2 != null)
        {
            e2.GetComponent<ChildElementControl>().enabled = false;
            childElementList.Remove(e2);
        }


        return isClosed;
    }
}

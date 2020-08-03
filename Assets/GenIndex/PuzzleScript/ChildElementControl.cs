using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildElementControl : MonoBehaviour
{
    [System.NonSerialized]
    public Transform elementMain;

    public string elementClass="None";
    public string elementValue = "None";

    private void Start()
    {
        elementMain = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, 100f, 1 << 8);
            RaycastHit hit2;
            Physics.Raycast(ray, out hit2);
            if (hit2.collider.transform == elementMain)
            {
                transform.position = new Vector3(hit.point.x, 0, hit.point.z);
            }
        }
    }
}

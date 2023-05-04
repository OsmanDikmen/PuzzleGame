using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mBoxes : MonoBehaviour
{
    Camera camMain;
    Vector2 firstPos;

    GameObject[] boxArray; 
    
    void OnMouseDrag()
    {
        Vector3 pos = camMain.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        transform.position = pos;
    }


    void Start()
    {
        camMain = GameObject.Find("Main Camera").GetComponent<Camera>();
        firstPos = transform.position;

        boxArray = GameObject.FindGameObjectsWithTag("Box");
    }


    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            foreach(GameObject box in boxArray)
            {
                if(box.name ==  gameObject.name)
                {
                    float distance = Vector3.Distance(box.transform.position, transform.position);
                    if(distance <= 1)
                    {
                        transform.position = box.transform.position;
                    }
                    else
                    {
                        transform.position = firstPos;
                    }
                }
            }
        }
    }
}

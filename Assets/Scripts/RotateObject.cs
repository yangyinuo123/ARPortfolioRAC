using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public List<GameObject> myObjs;
    public float interval;
    public float angle;
    private float speed;
    void Start()
    {
        speed = angle / interval;
    }
    void Update()
    {
        if (Time.time < interval)
        {
            RotateOneObj(myObjs[0]);
        }
        else if (interval< Time.time && Time.time  < interval * 2)
        {
            RotateOneObj(myObjs[1]);
        }
        else if (interval * 2 < Time.time && Time.time < interval * 3)
        {
            RotateOneObj(myObjs[2]);
        }

    }
    private void RotateOneObj(GameObject obj)
    {
        obj.transform.Rotate(0, 0, speed*Time.deltaTime, Space.Self);
    }
}

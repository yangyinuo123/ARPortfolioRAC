using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnfoldObj : MonoBehaviour
{
    public List<GameObject> myObjs;
    public float angle;
    public float interval;
    private float speed;
    private bool state = false;
    private List<Quaternion> rotationList = new List<Quaternion>();
    private float tempTime;
    void Start()
    {
        speed = angle / interval;
        foreach (var obj in myObjs)
        {
            rotationList.Add(obj.transform.localRotation);
        }

        //List<int> listA = new List<int>() { 0, 1, 2, 3 };
        ////List<int> listB;
        ////listB = listA;

        //List<int> listB = new List<int>();
        //foreach (var item in listA)
        //{
        //    listB.Add(item);
        //}

        //listB.Add(4);
    }
    public void OnUIUnFoldWall()
    {
        state = !state;
        tempTime = Time.time;
    }
    void Update()
    {
        if (state)
        {
            if ((Time.time - tempTime) < interval)
            {
                RotateOneObj(myObjs[0]);
            }
            else if ((Time.time - tempTime) > interval && (Time.time - tempTime) < interval * 2)
            {
                RotateOneObj(myObjs[1]);
            }
            else if ((Time.time - tempTime) > interval * 2 && (Time.time - tempTime) < interval * 3)
            {
                RotateOneObj(myObjs[2]);
            }
            else if ((Time.time - tempTime) > interval * 3 && (Time.time - tempTime) < interval * 4)
            {
                RotateOneObj(myObjs[3]);
            }
        }
        else
        {
            ResetAllRotation();
        }

    }
    private void RotateOneObj(GameObject obj)
    {
        obj.transform.Rotate(speed * Time.deltaTime, 0, 0);
    }
    private void ResetAllRotation()
    {
        for (int i = 0; i < myObjs.Count; i++)
        {
            myObjs[i].transform.localRotation = rotationList[i];
        }
    }
}

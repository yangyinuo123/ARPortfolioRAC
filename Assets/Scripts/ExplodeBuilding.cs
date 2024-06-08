using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeBuilding : MonoBehaviour
{
    public float moveScale;
    public List<GameObject> myObjs = new List<GameObject>();
    public GameObject parentObj;
    public GameObject explodeCenter;
    private List<Vector3> originVecList = new List<Vector3>();
    private bool state = false;

    private void Start()
    {
        if(myObjs.Count == 0)
        {
            CollectChildObject();
        }
        foreach (var obj in myObjs)
        {
            originVecList.Add(obj.transform.localPosition);
        }
    }
    private void CollectChildObject()
    {
        foreach (Transform child in parentObj.transform)
        {
            myObjs.Add(child.gameObject);
        }
    }
    public void OnUIExplode()
    {
        state = !state;
        if(state)
        {
            MoveAll();
        }
        else
        {
            ResetAll();
        }
    }
    private void MoveAll()
    {
        for (int i = 0; i < myObjs.Count; i++)
        {
            MovePosition(i);
        }
    }
    private void ResetAll()
    {
        for (int i = 0; i < myObjs.Count; i++)
        {
            ResetPosition(i);
        }
    }
    private void MovePosition(int i)
    {
        //float x = myObjs[i].transform.localPosition.x;
        //float z = myObjs[i].transform.localPosition.z;
        if(i == 0)
        {
            Debug.Log(myObjs[i].transform.position);
        }
        Vector3 direction = myObjs[i].gameObject.transform.position - explodeCenter.transform.position;
        direction *= moveScale -1;

        myObjs[i].gameObject.transform.position += direction;

        //x *= moveScale - 1;
        //z *= moveScale - 1;

        //myObjs[i].transform.localPosition += new Vector3(x, 0, z);
    }
    private void ResetPosition(int i)
    {
        myObjs[i].transform.localPosition = originVecList[i];
    }
}
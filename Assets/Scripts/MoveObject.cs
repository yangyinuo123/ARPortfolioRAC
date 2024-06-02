using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public List<GameObject> myObjs;
    public float time;
    public List<Vector3> startPosList;

    List<Vector3> originPosList = new List<Vector3>();
    List<Vector3> directionList = new List<Vector3>();
    List<Vector3> speedList = new List<Vector3>();
    List<bool> stateList = new List<bool>();
    int currentNumber = -1;
    private void Start()
    {
        foreach (var obj in myObjs)
        {
            originPosList.Add(obj.transform.localPosition);
        }
        for (int i = 0; i < myObjs.Count; i++)
        {
            directionList.Add(originPosList[i] - startPosList[i]);
            speedList.Add((originPosList[i] - startPosList[i])/time);
            stateList.Add(false);
        }
    }
    private void Update()
    {
        for (int i = 0; i < myObjs.Count; i++)
        {
            if (stateList[i])
            {
                ObjMovingByTime(i);
            }
        }
    }
    private void ObjMovingByTime(int i)
    {
        if(Vector3.Distance(myObjs[i].transform.localPosition, originPosList[i]) > 0.1)
        {
            myObjs[i].transform.localPosition += speedList[i] * Time.deltaTime;
        }
        else
        {
            stateList[i] = false;
        }
    }
    private void MoveAllProjects()
    {
        for (int i = 0; i < myObjs.Count; i++)
        {
            ObjMovingByTime(i);
        }
    }
    public void OnUIStartEnd()
    {
        for (int i = 0; i < myObjs.Count; i++)
        {
            myObjs[i].transform.localPosition = startPosList[i];
        }
        
        //state = true;
    }
    public void OnUIMoveOneByOne()
    {
        if(currentNumber == -1)
        {
            for (int i = 0; i < myObjs.Count; i++)
            {
                myObjs[i].transform.localPosition = startPosList[i];
            }
            currentNumber += 1;
        }
        else
        {
            if (currentNumber < myObjs.Count)
            {
                stateList[currentNumber] = true;
                currentNumber += 1;
            }
        }
    }
}

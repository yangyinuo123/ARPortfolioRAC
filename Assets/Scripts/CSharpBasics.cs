using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSharpBasics : MonoBehaviour
{
    public int numberA = 1;
    public int numberB = 2;
    string myString = "this is the beginner tutorial of c#";
    string myString2 = ", enjoy!";
    bool myBool = true;

    public Material red;
    public Material green;
    public Material blue;

    public GameObject cube;

    public List<GameObject> myCubes;

    public float interval = 2;
    float previousTime = 0;

    private void Start()
    {
        //Debug.Log("hellow world");
        //Debug.Log(numberA + numberB);
        //string myString3 = myString + myString2;
        //Debug.Log(myString3);
        //Debug.Log(!myBool);
        //Compare2Numbers(numberA, numberB);
        //bool result = Compare2NumbersReturnBool(numberA, numberB);

        //List<int> myIntList = new List<int>() { 0, 4, 6, 10 };

        //myIntList.Add(20);
        //myIntList.Remove(6);
        //myIntList.RemoveAt(1);

        //for (int i = 0; i < myIntList.Count; i++)
        //{
        //    //Debug.Log(myIntList[i]);
        //}


    }
    private void Update()
    {
        float t = Time.time;
        if (t - previousTime > interval)
        {
            Debug.Log(t);
            previousTime = t;
        }
    }

    private void Compare2Numbers(int A, int B)
    {
        if (A > B)
        {
            Debug.Log("A is larger than B");
        }
        else
        {
            Debug.Log("A is smaller than B");
        }
    }

    private bool Compare2NumbersReturnBool(int A, int B)
    {
        return A > B;
    }

    private void ChangeColor()
    {
        MeshRenderer renderer = cube.GetComponent<MeshRenderer>();

        if (Input.GetKey(KeyCode.R))
        {
            renderer.material = red;
        }
        else if (Input.GetKey(KeyCode.G))
        {
            renderer.material = green;
        }
        else if (Input.GetKey(KeyCode.B))
        {
            renderer.material = blue;
        }
    }
    private void LoopChangeColor()
    {
        Debug.Log("change color");
    }

    private void ActiveGameObject()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            cube.SetActive(!cube.activeSelf);
        }
    }
}

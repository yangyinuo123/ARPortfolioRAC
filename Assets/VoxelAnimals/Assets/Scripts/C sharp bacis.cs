using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int numberA = 1;
    public int numberB = 2;  
    //bool myBool = true;        
    //string myString1 = "this is the beginner tutorial od c#";
    //string myString2 = ",enjoy!";

    public Material red;
    public Material green;
    public Material blue;

    public GameObject cube;

    public List<GameObject> mycubes;
    private void Start()
    {
        //Debug.Log("hellow world");
        //Debug.Log(numberA + numberB);
        //string myString3 = myString1 + myString2
        //Debug.Log(myString3);
        //Debug.Log(!myBool);
        Compare2Numbers(numberA, numberB);
        bool result = Compare2NumbersReturn(numberA, numberB);

        List<int> myIntList= new List<int>() { 0, 4, 6, 10 };
        myIntList.Add(20);
        myIntList.Remove(6);

        for (int i=0;i<myIntList.Count; i++)
        {
            Debug.Log(myIntList[i]);
        }
    }   
    private void Update()
    {
        ChangeColor();
    }
    private void Compare2Numbers(int A, int B)
    { 

        if(A>B)
        {
            Debug.Log("A is larger than B");
        }
        else
        {
            Debug.Log("B is larger than A");
        }

    }
    private bool Compare2NumbersReturn(int A, int B)
        {
            return A > B;
        }

    private void ChangeColor()
    {
        MeshRenderer renderer = cube.GetComponent<MeshRenderer>();
        if (Input.GetKey(KeyCode.R))
        {
            //CHANGE TO RED COLOR
            renderer.material = red;

        }
        else if (Input.GetKey(KeyCode.G))
        {
            //CHANGE TO RED COLOR
            renderer.material = green;
        }
        else if (Input.GetKey(KeyCode.B))
        {
            renderer.material = blue;
        }
    }
    private void LoopChangeColor()
    {

    }
 }

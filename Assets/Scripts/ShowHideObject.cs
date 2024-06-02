using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideObject : MonoBehaviour
{
    //public GameObject designA;
    //public GameObject designB;
    public List<GameObject> myObjects;
    public List<GameObject> myTexts;
    private int currentNumber = 0;
    public float interval;
    private float startTime = 0;

    //private void Start()
    //{
    //    designA.SetActive(true);
    //    designB.SetActive(false);
    //}
    //public void OnUISwitchDesign()
    //{
    //    designA.SetActive(!designA.activeSelf);
    //    designB.SetActive(!designB.activeSelf);
    //}
    public void OnUIShowOrHide()
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }
    public void OnUIShowHideList()
    {
        foreach (GameObject obj in myObjects)
        {
            obj.SetActive(!obj.activeSelf);
        }
    }
    public void OnUIShowOneByOne()
    {
        if(currentNumber < myObjects.Count)
        {
            myObjects[currentNumber].SetActive(!myObjects[currentNumber].activeSelf);
            myTexts[currentNumber].SetActive(!myTexts[currentNumber].activeSelf);

            currentNumber += 1;
        }
    }

    private void Update()
    {
        if((Time.time - startTime)>= interval)
        {
            ShowOneByOne();
            startTime = Time.time;
        }
    }
    private void ShowOneByOne()
    {
        if (currentNumber < myObjects.Count)
        {
            myObjects[currentNumber].SetActive(!myObjects[currentNumber].activeSelf);
            myTexts[currentNumber].SetActive(!myTexts[currentNumber].activeSelf);

            currentNumber += 1;
        }
    }
}

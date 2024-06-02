using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesignProgress : MonoBehaviour
{
    public List<GameObject> myObjs;
    private int currentStep = 0;

    public void OnUIShowDesignProgress()
    {
        if (currentStep == 0)
        {
            foreach (GameObject obj in myObjs)
            {
                obj.SetActive(false);
            }
            currentStep += 1;
        }
        else if(currentStep < myObjs.Count + 1)
        {
            myObjs[currentStep-1].SetActive(true);
            currentStep += 1;
        }
        else
        {
            currentStep = 0;
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour
{
    public List<GameObject> myDesigns = new List<GameObject>();
    public List<GameObject> myButtons = new List<GameObject>();

    private int state = 0;
    private void Start()
    {
        SwithDesign(0);
    }
    public void OnUISwitchDesign()
    {
        if(state < myDesigns.Count)
        {
            state += 1;
        }
        else
        {
            state = 0;
        }
        SwithDesign(state);
    }
    private void SwithDesignWithButton(int i)
    {
        for (int j = 0; j < myDesigns.Count; j++)
        {
            if(j != i)
            {
                myDesigns[j].SetActive(false);
                myButtons[j].SetActive(false);
            }
            else
            {
                myDesigns[j].SetActive(true);
                myButtons[j].SetActive(true);
            }
        }
    }
    private void SwithDesign(int i)
    {
        for (int j = 0; j < myDesigns.Count; j++)
        {
            if (j != i)
            {
                myDesigns[j].SetActive(false);
            }
            else
            {
                myDesigns[j].SetActive(true);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHOWHIDESobject : MonoBehaviour
{
    public GameObject designA;
    public GameObject designB;
    private void Start()
    {
        designA.SetActive(true);
        designB.SetActive(false);

    }
    public void OnUISwitchDesign()
    {
        designA.SetActive(!designA.activeSelf);
        designB.SetActive(!designB.activeSelf);
    }

}

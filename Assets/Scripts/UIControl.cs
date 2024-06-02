using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour
{
    public GameObject designA;
    public GameObject designB;
    private void Start()
    {
        designA.SetActive(true);
        designB.SetActive(false);
    }
    public void OnUIChangeDesign()
    {
        designA.SetActive(!designA.activeSelf);
        designB.SetActive(!designA.activeSelf);
    }
}

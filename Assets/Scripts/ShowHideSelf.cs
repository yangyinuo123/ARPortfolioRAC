using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideSelf : MonoBehaviour
{
    public void OnUIShowHideSelf()
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }
}

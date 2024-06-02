using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeBuilding : MonoBehaviour
{
    public float moveScale;
    private Vector3 originVec;
    private bool state = false;

    private void Start()
    {
        originVec = this.gameObject.transform.localPosition;
    }
    public void OnUIExplode()
    {
        if(!state)
        {
            MovePosition();
        }
        else
        {
            ResetPosition();
        }
    }
    private void MovePosition()
    {
        float x = this.gameObject.transform.localPosition.x;
        float z = this.gameObject.transform.localPosition.z;

        x *= moveScale - 1;
        z *= moveScale - 1;

        this.gameObject.transform.localPosition += new Vector3(x, 0, z);
        state = true;
    }
    private void ResetPosition()
    {
        this.gameObject.transform.localPosition = originVec;
        state = false;
    }
}
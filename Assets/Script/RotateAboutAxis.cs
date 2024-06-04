using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAboutAxis : MonoBehaviour
{
    public Vector3 pointA = new Vector3(1, 0, 1); // 点 A
    public Vector3 pointB = new Vector3(1, 1, 1); // 点 B
    public float rotationSpeed = 30f; // 旋转速度，度/秒
    public float targetAngle = 30f; // 目标旋转角度

    private bool isRotating = false;
    private bool rotateClockwise = true; // 用于切换旋转方向

    public void StartRotation()
    {
        if (!isRotating)
        {
            float angle = rotateClockwise ? targetAngle : -targetAngle;
            StartCoroutine(RotateByAngle(angle));
            rotateClockwise = !rotateClockwise; // 切换旋转方向
            //Debug.Log("Rotation direction changed. New rotateClockwise: " + rotateClockwise);
        }
    }

    private IEnumerator RotateByAngle(float angle)
    {
        isRotating = true;
        float rotatedAngle = 0f;

        // 计算旋转轴 (B - A)
        Vector3 rotationAxis = (pointB - pointA).normalized;

        // 计算旋转中心 (A)
        Vector3 rotationCenter = pointA;

        while (Mathf.Abs(rotatedAngle) < Mathf.Abs(angle))
        {
            float rotationStep = rotationSpeed * Time.deltaTime;
            float actualRotation = Mathf.Min(rotationStep, Mathf.Abs(angle) - Mathf.Abs(rotatedAngle))* Mathf.Sign(angle);
            
            // 旋转物体
            transform.RotateAround(rotationCenter, rotationAxis, actualRotation);
            rotatedAngle += actualRotation; // 保持方向
            yield return null;
        }

        // 确保物体到达精确的目标角度
        float remainingAngle = angle - rotatedAngle;
        if (remainingAngle != 0)
        {
            transform.RotateAround(rotationCenter, rotationAxis, remainingAngle);
        }

        isRotating = false;
    }
}

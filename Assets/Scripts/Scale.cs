using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    public GameObject objectA; // 单个物件 A
    public GameObject[] objectsB; // 用于存储 B 内的多个物件

    private Vector3 originalScaleA; // 用于存储 objectA 的原始大小
    private bool isScaled = false; // 状态变量，跟踪是否已放大

    private void Start()
    {
        objectA.SetActive(true);
        SetActiveForObjects(objectsB, true);
        originalScaleA = objectA.transform.localScale;
    }
    public void OnUiScale()
    {
        isScaled = !isScaled;
        ScaleObjectAAndHideObjectsB();
    }
    public void ScaleObjectAAndHideObjectsB()
    {
        if (!isScaled)
        {
            StartCoroutine(ScaleObject(objectA, originalScaleA, 1.0f));
            SetActiveForObjects(objectsB, true);
            isScaled = false;
        }
        else
        {
            SetActiveForObjects(objectsB, false);
            Vector3 targetScale = originalScaleA * 1.5f; // 放大尺寸
            StartCoroutine(ScaleObject(objectA, targetScale, 1.0f));
            isScaled = true;
        }
    }
    private IEnumerator ScaleObject(GameObject obj, Vector3 targetScale, float duration)
    {
        Vector3 initialScale = obj.transform.localScale;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            obj.transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        obj.transform.localScale = targetScale;
    }
    private void SetActiveForObjects(GameObject[] objects, bool isActive)
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(isActive);
        }
    }
}

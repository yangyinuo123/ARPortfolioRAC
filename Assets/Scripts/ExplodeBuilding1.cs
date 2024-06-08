using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeBuilding1: MonoBehaviour
{
    [System.Serializable]
    public class ObjectMovement
    {
        public GameObject objectToMove; // Ҫ�ƶ������
        public float moveMultiplier = 1.0f; // �ƶ�����
        [HideInInspector]
        public Vector3 originalPosition; // ԭʼλ��
    }

    public ObjectMovement[] objectsToMove; // ���ڴ洢Ҫ�ƶ�����������ƶ�����
    public float moveDuration = 1.0f; // �ƶ�����ʱ��

    private bool isMoved = false; // ״̬���������������Ƿ����ƶ�

    private void Start()
    {
        // ��¼ÿ�������ԭʼλ��
        foreach (ObjectMovement objMovement in objectsToMove)
        {
            objMovement.originalPosition = objMovement.objectToMove.transform.position;
        }
    }

    // ��������������ԭ����ƶ�
    public void ToggleMove()
    {
        if (isMoved)
        {
            // ����������ƶ�����ԭ��ԭʼλ��
            foreach (ObjectMovement objMovement in objectsToMove)
            {
                StartCoroutine(MoveAlongYAxis(objMovement.objectToMove, objMovement.originalPosition, moveDuration));
            }
        }
        else
        {
            // �������δ�ƶ������ƶ���Ŀ��λ��
            foreach (ObjectMovement objMovement in objectsToMove)
            {
                Vector3 targetPosition = objMovement.originalPosition + new Vector3(0, objMovement.moveMultiplier, 0);
                StartCoroutine(MoveAlongYAxis(objMovement.objectToMove, targetPosition, moveDuration));
            }
        }

        // �л�״̬
        isMoved = !isMoved;
    }

    // Э������ƽ���ƶ����
    private IEnumerator MoveAlongYAxis(GameObject obj, Vector3 targetPosition, float duration)
    {
        Vector3 initialPosition = obj.transform.position;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            obj.transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        obj.transform.position = targetPosition;
    }
}

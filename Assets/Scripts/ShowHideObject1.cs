//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ShowHideObject : MonoBehaviour
//{
//    public GameObject designA;
//    public GameObject designB;
//    public GameObject landscape;

//    private void Start()
//    {
//        designA.SetActive(true);
//        designB.SetActive(false);
//    }
//    public void OnUISwitchDesign()
//    {
//        designA.SetActive(!designA.activeSelf);
//        designB.SetActive(!designB.activeSelf);
//    }
//    public void OnUIShowOrHide()
//    {

//        landscape.SetActive(!landscape.activeSelf);
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideObject1 : MonoBehaviour
{
    public GameObject[] designAObjects; // ���ڴ洢 designA �ڵ��������
    public GameObject designB;
    public GameObject landscape;

    private int state = 0; // ״̬����

    private void Start()
    {
        SetActiveForObjects(designAObjects, true);
        designB.SetActive(true); // ȷ�� designB �ڿ�ʼʱҲ����ʾ��
    }

    public void OnUISwitchDesign()
    {
        switch (state)
        {
          
            case 0:
                // ���� designA
                SetActiveForObjects(designAObjects, false);
                state = 1;
                break;
            case 1:
                // ��ʾ designA������ designB
                SetActiveForObjects(designAObjects, true);
                designB.SetActive(false);
                state = 2; // �����Ϊ0��ʹ���´ΰ���ֱ�ӽ�����ʾ���������״̬
                break;  
            case 2:
             
                SetActiveForObjects(designAObjects, true);
                designB.SetActive(true);
                state = 0;
                break;
        }
    }

    public void OnUIShowOrHide()
    {
        landscape.SetActive(!landscape.activeSelf);
    }

    private void SetActiveForObjects(GameObject[] objects, bool isActive)
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(isActive);
        }
    }
}



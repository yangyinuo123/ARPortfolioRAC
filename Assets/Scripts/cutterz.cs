using UnityEngine;
using UnityEngine.UI;

public class cutterz : MonoBehaviour
{
    public Slider slider; // Reference to the slider
    public GameObject building; // Reference to the model
    public Material[] cuttingMaterials; // Array of cutting materials

    // Start is called before the first frame update
    void Start()
    {
        SetSliderMaxValue();
        slider.onValueChanged.AddListener(UpdateCutoff);
    }

    // Update is called once per frame
    void UpdateCutoff(float value)
    {
        foreach (Material mat in cuttingMaterials)
        {
            mat.SetFloat("_Cutoff", value);
        }
    }

    void SetSliderMaxValue()
    {
        if (building != null)
        {
            Renderer renderer = building.GetComponent<Renderer>();
            if (renderer != null)
            {
                float depth = renderer.bounds.size.z; // 获取模型的深度
                slider.maxValue = renderer.bounds.max.z; // 设置滑杆的最大值为模型在Z轴上的最大值
                slider.minValue = renderer.bounds.min.z; // 设置滑杆的最小值为模型在Z轴上的最小值
                slider.value = slider.maxValue; // 将滑杆初始值设置为最大值
                Debug.Log("Building depth: " + depth);
            }
            else
            {
                Debug.Log("No Renderer Component found");
            }
        }
    }
}


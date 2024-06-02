using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CuttingControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider; // Reference to the slider
    public GameObject building; //Reference to the model
    public Material[] cuttingMaterials; // Array of cutting materials

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
                float height = renderer.bounds.size.y;
                slider.maxValue = renderer.bounds.max.y;
                slider.minValue = renderer.bounds.min.y;
                slider.value = slider.maxValue;
                Debug.Log("Building height: " + height);
            }
            else
            {
                Debug.Log("No Renderer Component found");
            }
        }
    }
}

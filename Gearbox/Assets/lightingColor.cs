using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine;

public class lightingColor : MonoBehaviour
{

    public PostProcessVolume volume;
    public ColorGrading colorGrading;
    public float TimeOfDay;

    // Start is called before the first frame update
    void Start()
    {
        TimeOfDay = 12;
    }

    // Update is called once per frame
    void Update()
    {
        TimeOfDay += Time.deltaTime / 12;
        if (TimeOfDay >= 24)
        {
            TimeOfDay = 0;
        }
        if (TimeOfDay >= 12)
        {
            colorGrading.temperature.value = Mathf.Lerp(0, 100, TimeOfDay / 24);
        }
    }
}

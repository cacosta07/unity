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
        TimeOfDay += Time.deltaTime / 1;
        if (TimeOfDay >= 24)
        {
            TimeOfDay = 0;
        }
        if (TimeOfDay >= 12)
        {
            //volume.colorGrading.settings = new ColorGrading
            //{
            //    temperature = (TimeOfDay-12)*2,
            //};
        }
    }
}

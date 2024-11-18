using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine;

public class lightingColor : MonoBehaviour
{

    public PostProcessVolume volume;
    public float TimeOfDay;

    // Start is called before the first frame update
    void Start()
    {
        TimeOfDay = 12;
    }

    // Update is called once per frame
    void Update()
    {
        Mathf.Clamp(TimeOfDay, 0, 24);
        TimeOfDay += Time.deltaTime / 10;
    }
}

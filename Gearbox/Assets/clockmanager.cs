using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockmanager : MonoBehaviour
{
    public MovementHandler movementHandler;
    public lightingColor lightingColor;
    public int isminutesequals60;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var eulerAngles = transform.eulerAngles;
        transform.rotation = Quaternion.Euler(eulerAngles.x, eulerAngles.y, (-lightingColor.TimeOfDay*15*(isminutesequals60)));
    }
}

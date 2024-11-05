using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyfab : MonoBehaviour
{
    public MovementHandler movementHandler;
    public Sprite image1;
    public Sprite image2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (movementHandler.ignition == false & movementHandler.isTurning == false){
            GetComponent<Image>().sprite = image1;
        }else{
            GetComponent<Image>().sprite = image2;
        }


    }
}

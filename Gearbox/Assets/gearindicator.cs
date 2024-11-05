using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gearindicator : MonoBehaviour
{
    public MovementHandler movementHandler;
    public Sprite i1;
    public Sprite i2;
    public Sprite i3;
    public Sprite i4;
    public Sprite i5;
    public Sprite iR;
    public Sprite iP;
    public Sprite iN;
    public Sprite i0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (movementHandler.ignition == false & movementHandler.isTurning == false){
            GetComponent<Image>().sprite = i0;
            if (movementHandler.brake == 1)
            {
                GetComponent<Image>().sprite = iP;
            }

        }else{
            if (movementHandler.gear == 1)
            {
                GetComponent<Image>().sprite = i1;
            }
            if (movementHandler.gear == 2)
            {
                GetComponent<Image>().sprite = i2;
            }
            if (movementHandler.gear == 3)
            {
                GetComponent<Image>().sprite = i3;
            }
            if (movementHandler.gear == 4)
            {
                GetComponent<Image>().sprite = i4;
            }
            if (movementHandler.gear == 5)
            {
                GetComponent<Image>().sprite = i5;
            }
            if (movementHandler.gear == -1)
            {
                GetComponent<Image>().sprite = iR;
            }
            if (movementHandler.brake == 1)
            {
                GetComponent<Image>().sprite = iP;
            }
            if (movementHandler.gear == 0)
            {
                GetComponent<Image>().sprite = iN;
            }
        }
    }
}

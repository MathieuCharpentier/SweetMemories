using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLightOnOff : MonoBehaviour
{
    public Light lamp;
    bool on;

    public void SetOnOff()
    {
        if(on)
        {
            lamp.enabled = false;
            on = false;
        }
        else
        {
            lamp.enabled = true;
            on = true;
        }
    }
}

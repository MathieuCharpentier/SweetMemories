using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnInteract : MonoBehaviour
{

    public UnityEvent thisEvent;
    public float distance;
    public KeyCode touche;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray,out hit, distance))
        {
            if(hit.transform.name == gameObject.name)
            {
                if (Input.GetKeyDown(touche))
                {
                    Debug.Log("interact to  " + hit.transform.name);
                    thisEvent.Invoke();
                }
            }
        }
    }
}

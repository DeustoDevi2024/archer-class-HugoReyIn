using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fashlight : MonoBehaviour
{
    public Light spotlight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lightController();
    }

    private void lightController()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            spotlight.enabled = !spotlight.enabled;
        }
    }
}

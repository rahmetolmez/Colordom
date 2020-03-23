using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeClick : MonoBehaviour
{
    public int currentColorCode = -1;
    public Color red, orange, yellow, green, blue, purple;
    public Color currentColor;
    //public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(!animator.isActiveAndEnabled)
            //animator.enabled = false;

        if(Input.GetMouseButtonDown(0))
        {
            
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, 100.0f))
            {
                if(hit.transform != null)
                {
                    //Debug.Log(hit.transform.gameObject.name);

                    if (hit.transform.gameObject.name == "RedCube")
                    {
                        currentColorCode = 1;
                        currentColor = red;
                       
                        //animator.enabled = true;
                        //animator.Play("CubeAnimation");
                    }
                    if (hit.transform.gameObject.name == "OrangeCube")
                    {
                        currentColorCode = 2;
                        currentColor = orange;
                    }
                    if (hit.transform.gameObject.name == "YellowCube")
                    {
                        currentColorCode = 3;
                        currentColor = yellow;
                    }
                    if (hit.transform.gameObject.name == "GreenCube")
                    {
                        currentColorCode = 4;
                        currentColor = green;
                    }
                    if (hit.transform.gameObject.name == "BlueCube")
                    {
                        currentColorCode = 5;
                        currentColor = blue;
                    }
                    if (hit.transform.gameObject.name == "PurpleCube")
                    {
                        currentColorCode = 6;
                        currentColor = purple;
                    }
                }
            }
        }
    }
}

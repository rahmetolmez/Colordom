using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCube : MonoBehaviour
{
    public GameObject colorCubePrefab;
    Transform transformCube;
    Vector3 vect;
    // Start is called before the first frame update
    void Start()
    {
        

        // for (int i = 0; i < 5; i++)
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateCube()
    {
        vect.x = 20;
        vect.y = 0;
        vect.z = 0;

        GameObject b = Instantiate(colorCubePrefab, transformCube) as GameObject;
        b.transform.position = vect;
    }
}

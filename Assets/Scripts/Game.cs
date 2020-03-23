using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public ColorCube colorCube;
    public GameObject[] cubesArray;
    public CubeClick cubeClick;
    private int[,] selectedArea = new int[16, 16];
    private int[] board = new int[256];
    public Color red, orange, yellow, green, blue, purple;
    private Color currentColor;
    private int currentColorCode;
    

    void Start()
    {
        SetRandomColors();

        selectedArea[0, 0] = 1;
        currentColor = Color.white;
        currentColorCode = -1;
    }

    void Update()
    {
        /*if (Input.GetKey("r"))
        {
            currentColor = red;
            currentColorCode = 1;
        }
        else if (Input.GetKey("o"))
        {
            currentColor = orange;
            currentColorCode = 2;
        } 
        else if (Input.GetKey("y"))
        {
            currentColor = yellow;
            currentColorCode = 3;
        }
        else if (Input.GetKey("g"))
        {
            currentColor = green;
            currentColorCode = 4;
        }
        else if (Input.GetKey("b"))
        {
            currentColor = blue;
            currentColorCode = 5;
        }
        else if (Input.GetKey("p"))
        {
            currentColor = purple;
            currentColorCode = 6;
        }*/

        currentColorCode = cubeClick.currentColorCode;
        currentColor = cubeClick.currentColor;

        for (int c = 0; c < cubesArray.Length; c++)
        {
            int j = c % 16;
            int i = (int)Mathf.Floor(c / 16);

            if (selectedArea[i, j] == 1)
            {
                Vector3 vvv = new Vector3(2, 2, 2);
                var transf = cubesArray[c].GetComponent<Transform>();
                transf.Rotate(vvv);
                var cubeRenderer = cubesArray[c].GetComponent<Renderer>();
                cubeRenderer.material.SetColor("_Color", currentColor);
                board[c] = currentColorCode;
            }
        }
        ExpandSelectedArea();
    }

    void SetRandomColors()
    {
        int randomNumber;

        for (int i = 0; i < cubesArray.Length; i++)
        {
            randomNumber = Random.Range(1, 7);
            var cubeRenderer = cubesArray[i].GetComponent<Renderer>();
            if (randomNumber == 1)
            {
                cubeRenderer.material.SetColor("_Color", red);
              
            }
            else if (randomNumber == 2)
            {
                cubeRenderer.material.SetColor("_Color", orange);
           
            }
            else if (randomNumber == 3)
            {
                cubeRenderer.material.SetColor("_Color", yellow);
          
            }
            else if (randomNumber == 4)
            {
                cubeRenderer.material.SetColor("_Color", green);

            }
            else if (randomNumber == 5)
            {
                cubeRenderer.material.SetColor("_Color", blue);

            }
            else if (randomNumber == 6)
            {
                cubeRenderer.material.SetColor("_Color", purple);

            }

            board[i] = randomNumber;
        }
    }

    void ExpandSelectedArea()
    {
        bool close = false;

        while(!close)
        {
            for(int c = 0; c < cubesArray.Length; c++)
            {
                
                int j = c % 16;
                int i = (int)Mathf.Floor(c / 16);
                
                if (selectedArea[i, j] == 1)
                { 
                    if (j != 15 && board[DoubleIndexToSingle(i, j + 1)] == currentColorCode)
                        selectedArea[i, j + 1] = 1;
                    if (j != 0 && board[DoubleIndexToSingle(i, j - 1)] == currentColorCode)
                        selectedArea[i, j - 1] = 1;
                    if (i != 15 && board[DoubleIndexToSingle(i + 1, j)] == currentColorCode)
                        selectedArea[i + 1, j] = 1;
                    if (i != 0 && board[DoubleIndexToSingle(i - 1, j)] == currentColorCode)
                        selectedArea[i - 1, j] = 1;
                    else
                        close = true;
                }
                else
                    close = true;
            }
            
        }
    }

    public int DoubleIndexToSingle(int i, int j)
    {
        return ((i * 16) + j);
    }      

    public void Dbg()
    {
        for(int i = 0; i < 16; i++)
        {
            for(int j = 0; j < 16; j++)
            {
                Debug.Log(selectedArea[i, j]);
            }
        }
    }
}

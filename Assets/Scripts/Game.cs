using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public const int BOARD_SIZE = 16;
    public ColorCube colorCube;
    public GameObject[] cubesArray;
    public CubeClick cubeClick;
    private int[,] selectedArea = new int[BOARD_SIZE, BOARD_SIZE];
    private int[] board = new int[BOARD_SIZE * BOARD_SIZE];
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
        if(CheckWin() == true)
        {

        }

        if(GameEnded())
        {
            Debug.Log("ended");
            
        }
        currentColorCode = cubeClick.currentColorCode;
        currentColor = cubeClick.currentColor;

        for (int c = 0; c < cubesArray.Length; c++)
        {
            int j = c % BOARD_SIZE;
            int i = (int)Mathf.Floor(c / BOARD_SIZE);

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
                
                int j = c % BOARD_SIZE;
                int i = (int)Mathf.Floor(c / BOARD_SIZE);
                
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
        return ((i * BOARD_SIZE) + j);
    }      

    public void Dbg()
    {
        for(int i = 0; i < BOARD_SIZE; i++)
        {
            for(int j = 0; j < BOARD_SIZE; j++)
            {
                Debug.Log(selectedArea[i, j]);
            }
        }
    }

    private bool GameEnded()
    {
        if(Score.GetMovesLeft() <= 0)
        {
            return true;
        }
        return false;
    }

    private bool CheckWin()
    {
        for(int i = 0; i < BOARD_SIZE * BOARD_SIZE; i++)
        {
            if(board[i] != board[0])
            {
                return false;
            }
        }
        return true;
    }
}

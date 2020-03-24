using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private static int movesMade = 0;
    private static int movesLeft = 33;
    public TMPro.TextMeshPro movesMadeText;
    public TMPro.TextMeshPro movesLeftText;

    void Update()
    {
        movesMadeText = GameObject.Find("MoveNumber").GetComponent<TMPro.TextMeshPro>();
        movesMadeText.text = movesMade.ToString();

        movesLeftText = GameObject.Find("MoveLeftNumber").GetComponent<TMPro.TextMeshPro>();
        movesLeftText.text = movesLeft.ToString();
    }

    public static void MoveMade()
    {
        movesMade++;
        movesLeft--;
    }

    public static int GetMovesLeft()
    {
        return movesLeft;
    }
}

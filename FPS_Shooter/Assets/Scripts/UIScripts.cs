using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScripts : MonoBehaviour
{
    public static UIScripts Instance;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    private int score = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void Score()
    {
        score++;
        scoreText.text = "X = " + score;
    }


}

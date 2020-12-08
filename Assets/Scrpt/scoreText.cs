using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreText : MonoBehaviour
{
    public Text sText;
    public static int score = 0;

    // Update is called once per frame
    void Update()
    {
        sText.text = "Score: " + score.ToString();
    }

}

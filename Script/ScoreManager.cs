using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    float previousHeroX;
    public Transform heroCopy;
    private float score;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        previousHeroX = heroCopy.position.x;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (previousHeroX < heroCopy.position.x)
        {
            score += heroCopy.position.x - previousHeroX;
            previousHeroX = heroCopy.transform.position.x;
            scoreText.text = ((int)score).ToString();
            Debug.Log("Score is " + scoreText.text);
            GameOverMenu.distance = score;
        }
    }
}

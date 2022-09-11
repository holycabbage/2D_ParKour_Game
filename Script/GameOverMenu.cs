using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public Text distanceText;
    public Text fuelCanNumText;
    public static float distance;
    public static float fuelCanNum;

    private void Update()
    {
        fuelCanNumText.text = fuelCanNum.ToString();
        distanceText.text = ((int)distance).ToString();
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void BackHome()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }


}

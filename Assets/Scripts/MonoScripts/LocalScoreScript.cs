using UnityEngine;
using UnityEngine.UI;


public class LocalScoreScript : MonoBehaviour
{
    //[System.Serializable]
    //public class SaveQuestions;

    float multiplier;
    float currentScore;
    Text screenText;

    void Start()
    {
        screenText = gameObject.GetComponent<Text>();
        multiplier = 1;
        ResetScore();
    }

    void Update()
    {
        if (currentScore > 0)
        {
            currentScore -= Time.deltaTime * 25;
        }
        else
        {
            currentScore = 0;
        }

        screenText.text = "" + (int)currentScore;
    }

    public void ResetScore()
    {
        currentScore = 500;
    }

    public int GetScore(bool correctAnswer)
    {
        int effectiveScore;
        if (correctAnswer)
        {
            effectiveScore = (int)(currentScore * multiplier);
            multiplier++;
        }
        else
        {
            effectiveScore = 0;
            multiplier = 1;
        }

        currentScore = 500;

        return effectiveScore;
    }
}

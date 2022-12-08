using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public List<ScorePadTrigger> trigger = new List<ScorePadTrigger>();
    public int score;

    public TextMeshProUGUI scoreText;

    private void Start()
    {
        score = 0;
        scoreText.text = "score " + score.ToString();
    }
    public void SetScoreText(int score)
    {
        for (int i = 0; i < trigger.Count; i++)
        {
            if (score > this.score)
            {
                this.score = score + trigger[i].partsOnTrigger;
            }
        }
        scoreText.text = "score " + this.score.ToString();
    }
}

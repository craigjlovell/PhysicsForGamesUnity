using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePadTrigger : MonoBehaviour
{
    public int score;
    public int partsOnTrigger;
    public Score scoreManager;
    public List<Rigidbody> onPad = new List<Rigidbody>();

    private void Update()
    {
        foreach (Rigidbody enemyParts in onPad)
        {
            // check if dummy parts on pad are moving
            if (enemyParts.IsSleeping())
                scoreManager.SetScoreText(score * partsOnTrigger);
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy") // check for if dummy is on pad
        {
            if (other.GetComponent<Rigidbody>())
            {
                // add dummy parts to list
                onPad.Add(other.GetComponent<Rigidbody>());
                partsOnTrigger++;
            }
        }
    }
}

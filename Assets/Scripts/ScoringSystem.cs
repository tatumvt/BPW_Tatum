using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{

    public GameObject ScoreText;
    public int theScore;
    //public AudioSource collectSound;

   void OnTriggerEnter(Collider other)
    {
        //collectSound.Play();
        theScore += 50;
        ScoreText.GetComponent<Text>().text = "SCORE: " + theScore;
        Destroy(gameObject);
    }

}

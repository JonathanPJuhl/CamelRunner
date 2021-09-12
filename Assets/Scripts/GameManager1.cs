using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager1 : MonoBehaviour
{

    public int score;
    public static GameManager1 inst;
    [SerializeField] Text scoreText;

    public void IncrementScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }
    private void Awake()
    {
        inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

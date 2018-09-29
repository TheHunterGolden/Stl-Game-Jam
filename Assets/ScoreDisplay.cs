using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField]
    private Score s;

    void Start()
    {
        s.score = 0;
        gameObject.GetComponent<Text>().text = s.score.ToString();
    }

    void Update() {
        s.setScore(0);
        gameObject.GetComponent<Text>().text = s.score.ToString();

    } 

}

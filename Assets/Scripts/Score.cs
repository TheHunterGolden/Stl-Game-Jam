using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Score", menuName ="Score")]
public class Score : ScriptableObject {

    
    public int score;

    public void resetScore() {
        score = 0;
    }

    public void setScore(int s) {
        score += s;
    }
}

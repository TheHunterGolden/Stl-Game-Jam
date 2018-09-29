using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScoreEventListener : GameEventListener {


    public abstract void RaiseEvent(int score);

    
}

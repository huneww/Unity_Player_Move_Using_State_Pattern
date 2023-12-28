using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    public void Action();
}

public enum STATE
{
    IDLE,
    MOVE,
    ATTACK,
    ATTACK1
}
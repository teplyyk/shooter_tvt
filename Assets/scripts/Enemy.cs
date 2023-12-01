using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public bool _Alive = true;
    public void Live(bool alive)
    {
        _Alive = alive;
    }
}

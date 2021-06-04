﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverOnTrigger : MonoBehaviour
{
    public string tagFilter;
    public textControler state;
    private void OnTriggerEnter(Collider other) // 1
    {
        if (other.CompareTag(tagFilter)) // 2
        {
            state.win(); // 3
        }
    }
}

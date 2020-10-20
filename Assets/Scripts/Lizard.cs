﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D otherColider)
    {
        GameObject otherObject = otherColider.gameObject;

        if (otherObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(otherObject);
        }

    }
}

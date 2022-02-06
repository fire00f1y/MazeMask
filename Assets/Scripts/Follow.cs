using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject follow;

    public void FixedUpdate()
    {
        if (follow != null) transform.position = follow.transform.position;
    }
}

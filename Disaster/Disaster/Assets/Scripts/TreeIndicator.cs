using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeIndicator : MonoBehaviour
{
    public ParticleSystem particle;

    void Start()
    {
        particle.Stop();
    }
}

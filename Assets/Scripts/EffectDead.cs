using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDead : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 5);
    }

}

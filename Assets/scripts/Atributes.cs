using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atributes : MonoBehaviour
{
    public float Health = 0.5f;

    public void ChangeHeath(float val)
    {
        Health += val;
    }
}

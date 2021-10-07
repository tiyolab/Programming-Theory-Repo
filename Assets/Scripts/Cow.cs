using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : Animal   // INHERITANCE
{
    protected override void Start() // POLYMORPHISM
    {
        base.Start();
        Speed = 3f;
    }
}

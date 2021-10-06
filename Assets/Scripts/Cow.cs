using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : Animal
{
    protected override void Start()
    {
        base.Start();
        Speed = 3f;
    }
}

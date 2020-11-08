using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionStep : Step
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // called when the step is completed.
    public override void OnStepCompletion()
    {
        gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

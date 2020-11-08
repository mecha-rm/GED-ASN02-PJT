using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveStep : Step
{
    // the subject being watched 
    public GameObject subject = null;

    // watch to see when the object becomes active, or inactive
    public bool watchForActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // called when the step is completed.
    public override void OnStepCompletion()
    {
        throw new System.NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

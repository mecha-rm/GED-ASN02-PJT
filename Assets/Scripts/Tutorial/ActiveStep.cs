using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveStep : Step
{
    // the subject being watched 
    public GameObject subject = null;

    // a list of objects that are relevant to the step.
    public List<GameObject> objects;

    // watch to see when the object becomes active, or inactive
    public bool watchForActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // called when this step starts.
    public override void OnStepActivation()
    {
        // makes all objects part of the step active.
        foreach (GameObject obj in objects)
            obj.SetActive(true);
    }

    // called when the step is completed.
    public override void OnStepCompletion()
    {
        // makes all objects part of the step inactive.
        foreach (GameObject obj in objects)
            obj.SetActive(false);

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // trigger
        if(subject.active == watchForActive && checklist.GetCurrentStep() == this)
        {
            checklist.CompleteStep();
        }
    }
}

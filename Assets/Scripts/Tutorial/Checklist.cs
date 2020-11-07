using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checklist : MonoBehaviour
{
    // the steps in the checklist.
    public Queue<Step> steps;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // adds a step to the list of steps for the checklist.
    public void AddStep(Step newStep)
    {
        steps.Enqueue(newStep);
    }

    // gets the current step
    public Step GetCurrentStep()
    {
        return steps.Peek();
    }

    // clears out all steps
    public void ClearSteps()
    {
        steps.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

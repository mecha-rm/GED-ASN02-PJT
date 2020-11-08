using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checklist : MonoBehaviour
{
    // the steps in the checklist.
    public Queue<Step> steps = new Queue<Step>();

    // the amount of steps that have been completed.
    private int stepsCompleted = 0;

    // destroys steps upon completing them.
    public bool destroySteps = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // adds a step to the list of steps for the checklist.
    public void AddStep(Step newStep)
    {
        steps.Enqueue(newStep);
        newStep.OnStepAddition(this);
    }

    // completes a step, which pops it off of the queue.
    public void CompleteStep()
    {
        // if there are no steps
        if (steps.Count == 0)
            OnCompleteList();

        Step doneStep = steps.Dequeue();
        doneStep.OnStepCompletion();

        // if the step should be destroyed.
        if (destroySteps)
            Destroy(doneStep);

        // list is completed. 
        if (steps.Count == 0)
            OnCompleteList();
    }

    // gets the current step
    public Step GetCurrentStep()
    {
        return steps.Peek();
    }

    // gets the number of the current step (starting at 1).
    // the index of this step is its step number minus 1.
    public int GetCurrentStepNumber()
    {
        return stepsCompleted + 1;
    }
    
    // gets the remaining step amount.
    public int GetRemainingStepCount()
    {
        return steps.Count;
    }

    // gets the number of completed steps
    public int GetNumberOfCompletedSteps()
    {
        return stepsCompleted;
    }

    // clears out all steps
    public void ClearSteps()
    {
        steps.Clear();
    }

    // returns 'true' if the list is complete.
    public bool IsCompleteList()
    {
        return steps.Count == 0;
    }

    // called when a list is completed.
    public void OnCompleteList()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

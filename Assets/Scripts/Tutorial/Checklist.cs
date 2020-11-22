using System.Collections.Generic;
using UnityEngine;

public class Checklist : MonoBehaviour
{
    // the steps in the checklist.
    // TODO: replace with regular List
    public Queue<Step> stepsLeft = new Queue<Step>();

    // a list of the steps that are used for the quest. This is used to show all steps.
    private List<Step> stepList = new List<Step>();

    // sets whether the checklist has been activated or not.
    public bool activeList = true;

    // the amount of steps that have been completed.
    private int stepsCompleted = 0;

    // destroys steps upon completing them.
    // public bool destroySteps = true;

    // Start is called before the first frame update
    void Start()
    {
        // starts the first step if there are steps
        if (activeList && stepsLeft.Count > 0)
            stepsLeft.Peek().OnStepActivation();
    }

    // if the list is active
    public void SetActiveList(bool active)
    {
        activeList = active;

        // if there are steps in the active list.
        if (activeList && stepsLeft.Count > 0)
            stepsLeft.Peek().OnStepActivation();

    }

    // adds a step to the list of steps for the checklist.
    public void AddStep(Step newStep)
    {
        stepsLeft.Enqueue(newStep);
        newStep.OnStepAddition(this);

        // adds a new step to the quest list.
        stepList.Add(newStep);
    }

    // completes a step, which pops it off of the queue.
    public void CompleteStep()
    {
        // if there are no steps
        if (stepsLeft.Count == 0)
            OnCompleteList();

        Step doneStep = stepsLeft.Dequeue();
        doneStep.OnStepCompletion();

        // if the step should be destroyed.
        // if (destroySteps)
        //     Destroy(doneStep);

        // list is completed. 
        if (stepsLeft.Count == 0)
            OnCompleteList();

        stepsCompleted++;

        // if there are still steps remaining. 
        if (stepsLeft.Count > 0)
            stepsLeft.Peek().OnStepActivation();
    }

    // gets the current step
    public Step GetCurrentStep()
    {
        return (stepsLeft.Count == 0) ? null : stepsLeft.Peek();
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
        return stepsLeft.Count;
    }

    // gets the number of completed steps
    public int GetNumberOfCompletedSteps()
    {
        return stepsCompleted;
    }

    // TODO: add ability to remove step

    // clears out all steps
    public void ClearSteps()
    {
        stepsLeft.Clear();
        stepList.Clear();
    }

    // returns 'true' if the list is complete.
    public bool IsCompleteList()
    {
        return stepsLeft.Count == 0;
    }

    // called when a list is completed.
    public void OnCompleteList()
    {

    }

    // restarts the list
    public void RestartQuest()
    {
        // clears out all steps
        stepsLeft.Clear();
        
        // while there are steps left
        // while(stepsLeft.Count != 0)
        // {
        // 
        // }

        // adds in all steps again
        foreach(Step step in stepList)
        {
            stepsLeft.Enqueue(step);
            step.OnStepAddition(this);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

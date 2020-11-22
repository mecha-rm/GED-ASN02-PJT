using System.Collections.Generic;
using UnityEngine;

public class Checklist : MonoBehaviour
{
    // the steps in the checklist.
    // TODO: replace with regular List
    public List<Step> steps;

    public int currentStep = 0;

    // sets whether the checklist has been activated or not.
    public bool activeList = true;

    // the amount of steps that have been completed.
    // private int stepsCompleted = 0;

    // destroys steps upon completing them.
    // public bool destroySteps = true;

    // Start is called before the first frame update
    void Start()
    {
        // starts the first step if there are steps
        if (activeList && steps.Count > 0)
            steps[currentStep].OnStepActivation();
    }

    // if the list is active
    public void SetActiveList(bool active)
    {
        activeList = active;

        // if there are steps in the active list.
        if (activeList && steps.Count > 0)
            steps[currentStep].OnStepActivation();

    }

    // adds a step to the list of steps for the checklist.
    public void AddStep(Step newStep)
    {
        steps.Add(newStep);
        newStep.OnStepAddition(this);
    }

    // removes a step from the list and reutrns it
    public void RemoveStep(Step step)
    {
        // if the step list contains the provided step
        if(steps.Contains(step))
        {
            int index = steps.IndexOf(step);
            steps.Remove(step);

            // if the step removed was behind the current step, move current step one back.
            if(index < currentStep)
            {
                currentStep--;
            }
            else if(index == currentStep) // current step was removed
            {
                // if the quest is now finished.
                if (currentStep >= steps.Count)
                    OnCompleteList();
                else
                    steps[currentStep].OnStepActivation();
            }
        }
    }

    // removes a step from the list via its index
    public Step RemoveStep(int index)
    {
        if(index >= 0 && index < steps.Count)
        {
            Step step = steps[index];
            steps.RemoveAt(index);
            return step;
        }
        else
        {
            return null;
        }
    }

    // deletes a step from the list
    public void DeleteStep(Step step)
    {
        RemoveStep(step);
        Destroy(step);
    }

    // deletes a step
    public void DeleteStep(int index)
    {
        Step step = RemoveStep(index);
        Destroy(step);
    }

    // completes a step, which pops it off of the queue.
    public void CompleteStep()
    {
        // if there are no steps
        if (steps.Count == 0)
            OnCompleteList();

        Step doneStep = steps[currentStep];
        doneStep.OnStepCompletion();

        // if the step should be destroyed.
        // if (destroySteps)
        //     Destroy(doneStep);

        currentStep++;
        // stepsCompleted++;

        // list is completed. 
        if (currentStep >= steps.Count)
            OnCompleteList();
        else // if there are still steps remaining. 
            steps[currentStep].OnStepActivation();
    }

    // gets the current step
    public Step GetCurrentStep()
    {
        return (steps.Count == 0 || currentStep >= steps.Count) ? null : steps[currentStep];
    }

    // gets the number of the current step (starting at 1).
    // the index of this step is its step number minus 1.
    public int GetCurrentStepNumber()
    {
        return currentStep + 1;
    }

    // gets the remaining step amount. This includes the current step.
    public int GetRemainingStepCount()
    {
        return steps.Count - currentStep;
    }

    // gets the number of completed steps
    public int GetNumberOfCompletedSteps()
    {
        // return stepsCompleted;
        return currentStep;
    }

    // clears out all steps
    public void ClearSteps()
    {
        steps.Clear();
        currentStep = 0;
        // stepsCompleted = 0;
    }

    // returns 'true' if the list is complete.
    public bool IsCompleteList()
    {
        return currentStep >= steps.Count;
    }

    // called when a list is completed.
    public void OnCompleteList()
    {

    }

    // restarts the list
    public void RestartQuest()
    {
        currentStep = 0;
        // stepsCompleted = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

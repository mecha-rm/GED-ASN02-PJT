﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// a step in the list
public abstract class Step : MonoBehaviour
{
    private Checklist todoList = null;
    // the number of the step in the list. Step numbers start at 1.
    string name = "";
    string desc = "";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // gets the checklist this step is part of.
    public Checklist GetChecklist()
    {
        return todoList;
    }

    // called when a step has been added to the list.
    public void OnStepAddition(Checklist newList)
    {
        todoList = newList;
    }

    // called when a step is completed.
    public abstract void OnStepCompletion();

    // checks to see if this is the current step
    public bool IsCurrentStep()
    {
        // if a list has been added, check to see if this is the current step.
        if (todoList != null)
            return this == todoList.GetCurrentStep();

        return false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

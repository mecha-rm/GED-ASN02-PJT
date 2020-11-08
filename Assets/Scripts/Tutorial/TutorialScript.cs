using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// class used for setting up the tutorial
public class TutorialScript : MonoBehaviour
{
    // checklist
    public Checklist tutorialList;

    // the list of steps to be added
    public List<Step> stepList;

    // the text used to show the step.
    public Text stepText = null;

    // Start is called before the first frame update
    void Start()
    {
        // gets the checklist if it hasn't been set.
        if(tutorialList == null)
            tutorialList = GetComponent<Checklist>();

        // goes through the steps list and adds them to the Checklist
        for(int i = 0; i < stepList.Count; i++)
        {
            tutorialList.AddStep(stepList[i]);
        }

        if(tutorialList != null)
        {
            if (!tutorialList.IsCompleteList())
                stepText.text = "Step " + tutorialList.GetCurrentStepNumber() + ": " + tutorialList.GetCurrentStep().description;
            else
                stepText.text = "Tutorial is Complete!";
        }
            

        // steps.Add(new Step());
    }

    // Update is called once per frame
    void Update()
    {
        // if the tutorial is complete.
        if(tutorialList.IsCompleteList())
        {
            string str = "All Steps Completed!";

            if (stepText.text != str)
                stepText.text = str;
        }
    }
}

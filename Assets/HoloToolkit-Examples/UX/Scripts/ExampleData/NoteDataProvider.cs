﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Examples.InteractiveElements
{
    public class NoteDataProvider : MonoBehaviour
    {
        public InteractiveGroup TargetGroup;

        public InteractiveSet SourceSet;

        // some test data - imagine this comming from a web-service or some input menu
        public Dictionary<string, List<string>> Data = new Dictionary<string, List<string>>
        {
            {
                "Normal",
                new List<string>(){
                    "Please contact me.",
                    "Please check\nthis component.",
                    "Please provide\nmore information."
                }
            },
            {
                "Warning", new List<string>(){
                    "Component needs to\nbe repaired.",
                    "Component needs to\nbe replaced.",
                    "Please provide\nmore information.",
                    "Wear a helmet",
                    "Use a mask",
                    "Wear boots",
                    "Take care:\nfire hazard.",
                    "Take care:\nchemicals."
                }
            }
        };

        /// <summary>
        /// called when clicked on one of the buttons at the SourceSet to 
        /// modify the TargetGroup data
        /// </summary>
        public void NoteTypeButtonSelected()
        {
            if (SourceSet.SelectedIndices.Count == 0)
            {
                return;
            }
            int interactivePos = SourceSet.SelectedIndices[0];
            LabelTheme label = SourceSet.Interactives[interactivePos].gameObject.GetComponent<LabelTheme>();
            if (label != null)
            {
                TargetGroup.Titles = Data[label.Default];
                TargetGroup.UpdateData();
            }
        }

        /// <summary>
        /// the user tapped the send button. If something is selected it will be logged.
        /// </summary>
        public void SendNote()
        {
            List<int> selected = TargetGroup.GetInteractiveSet().SelectedIndices;
            foreach (int index in selected)
            {
                Debug.Log("Send new note: " + TargetGroup.Titles[index]);
            }
            if (selected.Count == 0)
            {
                Debug.Log("Please select a note.");
            }
        }
    }
}

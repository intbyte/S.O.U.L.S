using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionManager : MonoBehaviour
{
    public Text instructionText;
    public Text buttonText;
    public Image instructorImage;
    List<string> list;
    int index = 0;
    public void ShowInstruction (List<string> stringList, Sprite instructor) {
        GameObject.FindObjectOfType<GameManager> ().StopAll ();
        list = new List<string> ();
        foreach (string s in stringList)
            list.Add (s);
        index = 0;
        instructorImage.sprite = instructor;
        gameObject.SetActive (true);
        UpdateText ();
        UpdateButtonText ();
    }

    public void Next () {
        index++;
        if (index >= list.Count) {
            gameObject.SetActive (false);
            GameObject.FindObjectOfType<GameManager> ().StartAll ();
            return;
        }
        UpdateText ();
        UpdateButtonText ();
    }

    void UpdateText () {
        instructionText.text = list[index];
    }

    void UpdateButtonText () {
        if (index >= list.Count - 1) {
            buttonText.text = "Close";
        } else {
            buttonText.text = "Next";
        }
    }
}

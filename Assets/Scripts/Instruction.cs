using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruction : MonoBehaviour
{
    public List<string> instructions;
    public Sprite instructor;
    public InstructionManager insMan;

    public void OnMouseDown () {
        FindObjectOfType<AudioManager> ().Stop ("Read");
		FindObjectOfType<AudioManager> ().Play ("Read");
        insMan.ShowInstruction (instructions, instructor);
        Destroy (gameObject);
    }
}

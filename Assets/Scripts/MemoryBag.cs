using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryBag : MonoBehaviour {
    
    public List<CollectableMemory> bag;
    public Text memoryNumberUI;
    
    public void Start () {
        bag = new List<CollectableMemory> ();
        memoryNumberUI.text = bag.Count + "/7";
    }

    public void CollectMemory (CollectableMemory memory) {
        if (bag == null) {
            Debug.LogWarning ("memory bag list not initialized, initializing...");
            bag = new List<CollectableMemory> ();
        }
        if (memory != null) {
            bag.Add (memory);
            memoryNumberUI.text = bag.Count + "/7";
        }
    }
}

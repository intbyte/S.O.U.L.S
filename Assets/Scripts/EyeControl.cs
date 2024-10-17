using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeControl : MonoBehaviour {
    public Transform holder;
    public Transform eyeball;
    public Transform player;
    void Update () {
        Vector2 direction = player.position - holder.position;

        // Calculate the angle in degrees (y-axis pointing up is 0 degrees)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Since your pivot is at the top center, you need to offset by 90 degrees
        angle -= 90;

        // Rotate the eyeball to face the player
        holder.rotation = Quaternion.Euler (0, 0, angle);
        eyeball.rotation = Quaternion.identity;
    }
}

using System.Linq;
using UnityEngine;

public class Explosive : MonoBehaviour
{   
    public float radius = 3f;
    public GameObject ExplosionEffect;
    public void Explode()
    {
        Instantiate(ExplosionEffect, transform.position, transform.rotation);
        Collider2D[] touchedObjects = Physics2D.OverlapCircleAll (transform.position, radius).Where(x => x.tag == "Enemy").ToArray();
        //FindObjectOfType<AudioManager> ().Stop ("Blast");
		FindObjectOfType<AudioManager> ().Play ("Blast");
        foreach (Collider2D touchedObject in touchedObjects)
        { 
            var target = touchedObject.gameObject.GetComponent<UniversalHealth>();
            target.Damage (150 / Time.deltaTime);

        }
        Destroy(gameObject);
    }
}

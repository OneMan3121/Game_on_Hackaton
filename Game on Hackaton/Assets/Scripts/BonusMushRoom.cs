using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusMushRoom : MonoBehaviour
{
    public BonusManager bonusManager;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ball")
        {
            other.gameObject.transform.localScale = new Vector3(other.gameObject.transform.localScale.x * 3, other.gameObject.transform.localScale.y * 3, other.gameObject.transform.localScale.z * 3);
            other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 2; 
            Destroy(this.gameObject);
        }
        if(other.tag == "Player")
        {
            
            Destroy(this.gameObject);
        }
    }
}

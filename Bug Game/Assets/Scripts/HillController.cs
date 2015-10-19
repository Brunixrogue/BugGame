using UnityEngine;
using System.Collections;

public class HillController : MonoBehaviour {

    public float hp = 5.0f;
    
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        hp -= 1.0f;
        //Death Animation
        //Death Sound (Might go in Death()
        if (hp < 1)
        {
            Death();
        }
    }

    void Death()
    {     
        Destroy(gameObject);
    }




}

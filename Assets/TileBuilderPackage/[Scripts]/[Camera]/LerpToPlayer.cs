using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LerpToPlayer : MonoBehaviour {


    private GameObject player;
    
    private void Awake() {
		player = GameObject.FindGameObjectWithTag("Player");
    }
    
    private void FixedUpdate() {
		float xPosition = 0;
        float yPosition = 0;
    
        xPosition = player.transform.position.x;
        yPosition = player.transform.position.y;
        
        //Lerp the camera to the center point of all players on the screen.
        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(xPosition, yPosition, this.transform.position.z), 0.1f);
    }


}

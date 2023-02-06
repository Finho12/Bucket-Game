using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameoverScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other){
                // Ensure game is active
        if(!GameManager.Instance.isGameActive){
            return;
        }
    // Check if other objects is a ball
  if(other.gameObject.CompareTag("Ball")){

    //increment fail
    GameManager.Instance.fail++;
    Destroy(other.gameObject);

    Debug.Log ("Fail: " + GameManager.Instance.fail);
  }
  if (GameManager.Instance.fail == 3){
    Debug.Log("Game Over!");
   
        //destroy object
    Destroy(other.gameObject);

        //End game
    GameManager.Instance.isGameActive = false;

  }
}
}

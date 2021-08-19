using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public GameObject Doors;
    public GameObject Player;
    public GameObject Hint;

    private bool PlayerDetect;
    public Transform Pos;
    public float width;
    public float height;
    public LayerMask WhatisPlayer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDetect = Physics2D.OverlapBox(Pos.position, new Vector2(width, height), 0, WhatisPlayer);

        if(PlayerDetect == true) {
             Hint.SetActive(true);
             if(Input.GetKeyDown(KeyCode.F)) {
              StartCoroutine(DoorOpen());
             }
        }

        if(PlayerDetect == false) {
             Hint.SetActive(false);
        }
    }


    IEnumerator DoorOpen() {
        yield return new WaitForSeconds(0);
        SceneManager.LoadScene(5);
        //Destroy (Hint);
        //Player.transform.position = new Vector2(Doors.transform.position.x, Doors.transform.position.y);
    }

     private void OnDrawGizmosSelected() {
      Gizmos.color = Color.yellow;
      Gizmos.DrawWireCube(Pos.position, new Vector3(width, height, 1));  
    }
}
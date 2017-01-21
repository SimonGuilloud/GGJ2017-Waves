﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {

    public bool isLanded;
    public bool hasJump;
    public bool isOnWall;
    public bool isCasting;
    public bool isCrouched;
    public const float MAXLIFE=100;
    public float life;
    public float rpos;
    public Vector3 initPosition;

    worldController wc;

    // Use this for initialization
    void Start () {
        wc = Camera.main.GetComponent<worldController>();
        reset();
    }

    public void reset()
    {
        life = MAXLIFE;
        isLanded = false;
        this.transform.position = initPosition;
        GetComponent<SpriteRenderer>().sprite = GetComponent<PlayerController>().normalSprite;
        GetComponent<Animator>().enabled = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (!wc.isPaused())
        {
            relativePosition();
        }
	}

    void OnCollisionStay(Collision coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            isLanded = true;
        }
    }
    void OnCollisionExit(Collision coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            isLanded = false;
        }
    }

    void relativePosition()
    {
        rpos = gameObject.GetComponent<PlayerController>().otherPlayer.transform.position.x- this.transform.position.x;
        if (rpos > 0)
        {
            transform.localEulerAngles = Vector3.up*180;
        }
        else
        {
            transform.localEulerAngles = Vector3.zero;
        }
    }
}

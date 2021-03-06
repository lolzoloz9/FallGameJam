﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkPowerUp : MonoBehaviour {
    [SerializeField] private float activeTime;
    private GameObject player;
    private Vector2 defaultScale;

    private void Start() {
        defaultScale = player.transform.localScale;
    }

    public void Effect() {
        player.transform.localScale = new Vector2(0.5f, 0.5f);
        StartCoroutine(PowerUpLength(activeTime));
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            player = collision.gameObject;
            Effect();
        }
    }

    private IEnumerator PowerUpLength(float powerUpTime) {
        yield return new WaitForSeconds(powerUpTime);
        player.transform.localScale = defaultScale;
    }
}


﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    [SerializeField] private AudioClip _ammoAudioClip;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            var gun = player.Gun;
            var ammoToAdd = 25 * gun.MaxAmmo / 100;
            gun.AddAmmo(ammoToAdd);
            Destroy(gameObject);
            GameManager.Instance.AmmoBoxCount--;
            AudioManager.Instance.PlaySoundFx(_ammoAudioClip);
        }
    }
}
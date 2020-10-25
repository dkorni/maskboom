using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBox : MonoBehaviour
{
    [SerializeField] private AudioClip _healAudioClip;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerController>();
        if (player != null)
        {
           player.SetDamage(-10);
           AudioManager.Instance.PlaySoundFx(_healAudioClip);
           Destroy(gameObject);
           GameManager.Instance.HealBoxCount--;
        }
    }
}

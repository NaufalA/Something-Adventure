using System;
using System.Collections;
using System.Collections.Generic;
using Code.Scripts;
using UnityEngine;

public class NpcDetector : MonoBehaviour
{
    private NpcInteract _interact;

    private void Start()
    {
        _interact = GetComponent<NpcInteract>();
        _interact.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            _interact.enabled = true;
            _interact.SetTargetNpc(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            _interact.enabled = false;
        }
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARRaycastManager))]
public class Player : MonoBehaviour
{
    [SerializeField] Camera _camera;
    private ARRaycastManager _raycastManager;
    List<ARRaycastHit> _hits = new();

    private void Start()
    {
        _raycastManager = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: rework hitscan
        bool isAttacking = Input.touchCount > 0;
        if (isAttacking)
        {
            Ray ray = new(_camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f)), _camera.transform.forward);
            if (_raycastManager.Raycast(ray, _hits) && Physics.Raycast(ray, out RaycastHit hit))
            {
                bool isNPC = hit.collider.gameObject.CompareTag("NPC");
                Debug.Log($"Tag {hit.collider.gameObject.tag} is NPC {isNPC}");
                hit.collider.gameObject.SendMessage("TakeDamage");
            }
        }
    }

}


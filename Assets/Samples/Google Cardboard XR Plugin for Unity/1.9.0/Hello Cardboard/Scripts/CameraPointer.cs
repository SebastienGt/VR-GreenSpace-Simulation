//-----------------------------------------------------------------------
// <copyright file="CameraPointer.cs" company="Google LLC">
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.XR;
using System.Collections.Generic;
using TMPro;

/// <summary>
/// Sends messages to gazed GameObject.
/// </summary>
public class CameraPointer : MonoBehaviour {
    
    private int _state = 0; // 0 - not selecting ; 1 - selecting
    private GameObject _gazedAtObject = null;
    private GameObject _cursorInstance;
    private ParticleSystem _ps;
    private const float CONTROLLER_DEADZONE = 0.01f;
    private const float DURATION = 3f;
    private const float MAX_DISTANCE = 6f;
    private const float MAX_DISPLAY_TIME = 500f;
    private const float MAX_CURSOR_DISTANCE = 30f;
    private float _cursorHoverTimer = 0;
    public Camera viewCamera;
    public GameObject cursorPrefab;

    // Start is called before the first frame update
    void Start() {
        _cursorInstance = Instantiate(cursorPrefab);
        _ps = _cursorInstance.GetComponentInChildren<ParticleSystem>();
        var main = _ps.main;
        main.simulationSpeed = 3f / DURATION;
    }

    private void CheckControllerInput()
    {
        // Tentative controller input
        float vertical = Input.GetAxis("Vertical"); 
        float horizontal = Input.GetAxis("Horizontal");
        float speed = 5f;
        if (Mathf.Abs(vertical) > CONTROLLER_DEADZONE){
            //move in the direction of the camera
            transform.position += Camera.main.transform.forward * vertical * speed * Time.deltaTime;
        }
        if (Mathf.Abs(horizontal) > CONTROLLER_DEADZONE){
            //strafe sideways
            transform.position += new Vector3(0,0,-horizontal * speed* Time.deltaTime);        
        }
    }


    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    public void Update() {
        //CheckControllerInput();
        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed at
        RaycastHit hit;
        float dist = 0;
        if (Physics.Raycast(transform.position, transform.forward, out hit, MAX_DISTANCE)) {
            // GameObject detected in front of the camera.
            if (_gazedAtObject != hit.transform.gameObject) {            
                // New GameObject.
                _gazedAtObject?.SendMessage("OnPointerExit");
                _gazedAtObject = hit.transform.gameObject;
                _cursorHoverTimer = 0;
                _state = 1;
                
                _ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                _gazedAtObject.SendMessage("OnPointerEnter");
                var interactable = _gazedAtObject.GetComponent<InteractableObject>();
                if (interactable) {
                    dist = (transform.position - hit.transform.position).magnitude;
                    if (!(interactable.RequiresCloseDistance() && dist > MAX_DISTANCE))
                    {
                        if (interactable._interactable == true)
                        {
                            if (_gazedAtObject.GetComponent<Spot>())
                            {
                                if (Player.player.hasSeed && !hit.transform.gameObject.GetComponent<Spot>().hasPlant)
                                    _ps.Play();
                            }
                            else
                            {
                                _ps.Play();
                            }
                        }
                    }
                }
            } 
            else 
            {
                // Looking at the same GameObject
                if (_state == 1) {
                    if (_cursorHoverTimer >= DURATION)
                    {
                        _gazedAtObject?.SendMessage("OnPointerClick");
                        _cursorHoverTimer = 0;
                        _state = 0;
                        _ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

                    } 
                    else
                    {
                        _cursorHoverTimer += Time.deltaTime;
                    }
                }
            }
            // If the ray hits something, set the position to the hit point
            // and rotate to point away from the camera
            _cursorInstance.transform.position = hit.point;
            _cursorInstance.transform.rotation = Quaternion.FromToRotation(Vector3.up, -transform.forward);

        }
        else 
        {
            // No GameObject detected in front of the camera.
            _cursorHoverTimer = 0;
            _ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            _state = 0;
            _gazedAtObject?.SendMessage("OnPointerExit");
            // If the ray doesn't hit anything, set the position to the MAX_CURSOR_DISTANCE
            // and rotate to point away from the camera
            _cursorInstance.transform.position = transform.position + transform.forward.normalized * MAX_CURSOR_DISTANCE;
            _cursorInstance.transform.rotation = Quaternion.FromToRotation(Vector3.up, -transform.forward);
            _gazedAtObject = null;
        }

        // Checks for screen touches.
        if (Google.XR.Cardboard.Api.IsTriggerPressed)
        {
            _gazedAtObject?.SendMessage("OnPointerClick");
        }
    }

}

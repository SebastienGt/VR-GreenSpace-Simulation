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

/// <summary>
/// Sends messages to gazed GameObject.
/// </summary>
public class CameraPointer : MonoBehaviour {
    public Camera viewCamera;
    public GameObject cursorPrefab;
    public float maxCursorDistance = 30;
    private GameObject cursorInstance;
    ParticleSystem ps;
    ParticleSystem.MainModule main;

    int state = 0; // 0 - not selecting ; 1 - selecting
    float t1 = 0;
    private const float duration = 3f;
    private const float _maxDistance = 10;
    private GameObject _gazedAtObject = null;
    private void setT1(float t) {
        t1 = t;
    }
    private float getT1() {
        return t1;
    }

    // Start is called before the first frame update
    void Start() {
        cursorInstance = Instantiate(cursorPrefab);
        ps = cursorInstance.GetComponentInChildren<ParticleSystem>();
        main = ps.main;
        main.simulationSpeed = 3f / duration;
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    public void Update() {
        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance)) {
            // GameObject detected in front of the camera.
            if (_gazedAtObject != hit.transform.gameObject) {
                // New GameObject.
                _gazedAtObject?.SendMessage("OnPointerExit");
                _gazedAtObject = hit.transform.gameObject;
                setT1(0);
                state = 1;
                ps.Play();
                _gazedAtObject.SendMessage("OnPointerEnter");
            } else {
                // Looking at the same GameObject
                if (state == 1) {
                    if (getT1() >= duration) {
                        _gazedAtObject?.SendMessage("OnPointerClick");
                        setT1(0);
                        state = 0;
                        ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

                    } else {
                        setT1(getT1() + Time.deltaTime);
                    }
                }
            }
            // If the ray hits something, set the position to the hit point
            // and rotate based on the normal vector of the hit
            cursorInstance.transform.position = hit.point;
            cursorInstance.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);

        } else {
            // No GameObject detected in front of the camera.
            setT1(0);
            state = 0;
            _gazedAtObject?.SendMessage("OnPointerExit");
            // If the ray doesn't hit anything, set the position to the maxCursorDistance
            // and rotate to point away from the camera
            cursorInstance.transform.position = transform.position + transform.forward.normalized * maxCursorDistance;
            cursorInstance.transform.rotation = Quaternion.FromToRotation(Vector3.up, -transform.forward);
            _gazedAtObject = null;
        }

        // Checks for screen touches.
        if (Google.XR.Cardboard.Api.IsTriggerPressed) {
            _gazedAtObject?.SendMessage("OnPointerClick");
        }
    }

}

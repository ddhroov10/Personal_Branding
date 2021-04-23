using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using UnityEngine.Serialization;
using UnityEngine.XR.ARSubsystems;

public class PlacementProject : MonoBehaviour
{
    //[SerializeField]
    //private GameObject welcomePanel;

    [SerializeField]
    private PlacementObject_Project placedObject;

    [SerializeField]
    private Color activeColor = Color.red;

    [SerializeField]
    private Color inactiveColor = Color.gray;

    //[SerializeField]
    //private Button dismissButton;

    [SerializeField]                      //see
    private Camera arCamera;

    private Vector2 touchPosition = default;

    [SerializeField]
    private bool displayCanvas = true;


    void Awake()
    {
        //dismissButton.onClick.AddListener(Dismiss);
    }

    //pivate void Dismiss() => welcomePanel.SetActive(false);

    void Update()
    {
        // do not capture events unless the welcome panel is hidden
        //if (welcomePanel.activeSelf)                                                                          // see
        //return;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            touchPosition = touch.position;

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;

                // if we got a hit meaning that it was selected
                if (Physics.Raycast(ray, out hitObject))
                {
                    PlacementObject_Project placementObject = hitObject.transform.GetComponent<PlacementObject_Project>();
                    MeshRenderer placementObjectMeshRenderer = placedObject.GetComponent<MeshRenderer>();
                    if (placementObject != null)
                    {
                        placementObject.Selected = true;
                        placementObjectMeshRenderer.material.color = activeColor;

                        if (displayCanvas)
                        {
                            placementObject.ToggleCanvas();
                        }
                    }
                } // nothing selected so set the sphere color to inactive
                else
                {
                    PlacementObject_Project placementObject = placedObject.GetComponent<PlacementObject_Project>();
                    MeshRenderer placementObjectMeshRenderer = placedObject.GetComponent<MeshRenderer>();
                    if (placementObject != null)
                    {
                        placementObject.Selected = false;
                        placementObjectMeshRenderer.material.color = inactiveColor;

                        if (displayCanvas)
                        {
                            placementObject.ToggleCanvas();
                        }
                    }
                }
            }
        }
    }
}

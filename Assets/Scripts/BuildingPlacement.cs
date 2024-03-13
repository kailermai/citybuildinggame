using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacement : MonoBehaviour
{
    private bool currentlyPlacing;
    private bool currentlyBulldozering;

    private BuildingPreset curBuildingPreset;

    private float indicatorUpdateRate = 0.05f;
    private float lastUpdateTime;
    private Vector3 curIndicatorPos;

    public GameObject placementIndicator;
    public GameObject bulldozeIndicator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CancelBuildingPlacement();
        }

        if (Time.time - lastUpdateTime > indicatorUpdateRate)
        {
            lastUpdateTime = Time.time;
            curIndicatorPos = Selector.instance.GetCurTilePosition();

            if (currentlyPlacing)
            {
                placementIndicator.transform.position = curIndicatorPos;
            }

            else if (currentlyBulldozering)
            {
                bulldozeIndicator.transform.position = curIndicatorPos;
            }
        }
    }

    public void BeginNewBuildingPlacement(BuildingPreset preset)
    {
        // check money

        currentlyPlacing = true;
        curBuildingPreset = preset;
        placementIndicator.SetActive(true);
    }

    void CancelBuildingPlacement()
    {
        currentlyPlacing = false;
        placementIndicator.SetActive(false);
    }

    public void ToggleBulldoze()
    {
        currentlyBulldozering = !currentlyBulldozering;
        bulldozeIndicator.SetActive(currentlyBulldozering);
    }
}

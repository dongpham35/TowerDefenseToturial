using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;

    private Color baseColor;
    private Renderer rend;

    public GameObject turret;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        baseColor = rend.material.color;

        turret = null;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if(turret != null)
        {
            Debug.Log("Can't Build a new turret in here");
            return;
        }

        if (BuildManager.Instance.CanBuild)
            BuildManager.Instance.BuildTurretOn(this);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!BuildManager.Instance.CanBuild)
            return;
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = baseColor;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position;
    }
}

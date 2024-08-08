using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color NotEnounghMoney;

    private Color baseColor;
    private Renderer rend;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBluePrint;
    [HideInInspector]
    public bool isUpgrade = false;

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
            BuildManager.Instance.SelectedNode(this);
            return;
        }

        if (BuildManager.Instance.CanBuild)
            BuildTurretOn(BuildManager.Instance.getTurretToBuild());
    }

    public void BuildTurretOn(TurretBlueprint blueprint)
    {
        if (PlayerStats.money < blueprint.cost)
        {
            Debug.Log("Not enough money to build that");
            return;
        }

        PlayerStats.money -= blueprint.cost;

        GameObject _turret = Instantiate(blueprint.TurretPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject buildeffect = Instantiate(BuildManager.Instance.buildEffectPrefab, GetBuildPosition() + new Vector3(0, 1f, 0), Quaternion.identity);
        Destroy(buildeffect, 5f);
        turretBluePrint = blueprint;
        Debug.Log(turretBluePrint.TurretPrefab.name + " to build!");
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.money < turretBluePrint.costUpgrade)
        {
            Debug.Log("Not enough money to build that");
            return;
        }

        PlayerStats.money -= turretBluePrint.costUpgrade;

        //destroy an old turret
        Destroy(turret);

        //a new turret
        GameObject _turret = Instantiate(turretBluePrint.TurretUpgradePrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject buildeffect = Instantiate(BuildManager.Instance.buildEffectPrefab, GetBuildPosition() + new Vector3(0, 1f, 0), Quaternion.identity);
        Destroy(buildeffect, 5f);

        isUpgrade = true;
        Debug.Log("Turret upgrade!");
    }

    public void SellTurret()
    {
        PlayerStats.money += turretBluePrint.SellAmount(isUpgrade);
        Destroy(turret);
        GameObject selleffect = Instantiate(BuildManager.Instance.sellEffectPrefab, GetBuildPosition() + new Vector3(0, 1f, 0), Quaternion.identity);
        Destroy(selleffect, 5f);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!BuildManager.Instance.CanBuild)
            return;

        if (!BuildManager.Instance.EnounghMoney)
        {
            rend.material.color = NotEnounghMoney;
            return;
        }
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

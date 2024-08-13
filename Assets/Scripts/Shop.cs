using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardturretPrefab;
    public TurretBlueprint missilelauncherPrefab;
    public TurretBlueprint laserBeamerPrefab;


    public Text txtCostStadardTurret;
    public Text txtCostmissileLauncher;
    public Text txtCostLaserBeamerTurret;

    private void OnEnable()
    {
        txtCostStadardTurret.text = "$"+standardturretPrefab.cost.ToString();
        txtCostLaserBeamerTurret.text = "$"+laserBeamerPrefab.cost.ToString();
        txtCostmissileLauncher.text = "$"+missilelauncherPrefab.cost.ToString();
    }
    public void SetTurretToStandTurret()
    {
        BuildManager.Instance.SetTurretToBuild(standardturretPrefab);
    }

    public void SetTurretToMissileLauncher()
    {
        BuildManager.Instance.SetTurretToBuild(missilelauncherPrefab);
    }

    public void SetTurretToLaserBeamer()
    {
        BuildManager.Instance.SetTurretToBuild(laserBeamerPrefab);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardturretPrefab;
    public TurretBlueprint missilelauncherPrefab;
    public TurretBlueprint laserBeamerPrefab;

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

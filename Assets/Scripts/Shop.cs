using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardturretPrefab;
    public TurretBlueprint missilelauncherPrefab;

    public void SetTurretToStandTurret()
    {
        BuildManager.Instance.SetTurretToBuild(standardturretPrefab);
    }

    public void SetTurretToMissileLauncher()
    {
        BuildManager.Instance.SetTurretToBuild(missilelauncherPrefab);
    }
}

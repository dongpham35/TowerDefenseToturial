using System;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    public GameObject TurretPrefab;
    public int cost;

    public GameObject TurretUpgradePrefab;
    public int costUpgrade;

    public int SellAmount(bool isUpgrade)
    {
        return (int) (isUpgrade ? (costUpgrade + cost) / 2 : cost / 2);
    }
}

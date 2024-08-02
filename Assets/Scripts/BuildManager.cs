using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    //Singleton
    private static BuildManager instance;
    public static BuildManager Instance { get => instance; }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private TurretBlueprint TurretToBuild;

    public bool CanBuild { get { return  TurretToBuild != null; } }
    public void SetTurretToBuild(TurretBlueprint turret)
    {
        TurretToBuild = turret;
    }

    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.money < TurretToBuild.cost)
        {
            Debug.Log("Not enough money to build that");
            return;
        }

        PlayerStats.money -= TurretToBuild.cost;

        GameObject turret = Instantiate(TurretToBuild.TurretPrefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret build!");
    }
    

    private void Start()
    {
        TurretToBuild = null;
    }
}

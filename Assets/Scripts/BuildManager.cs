using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public GameObject buildEffectPrefab;
    public GameObject sellEffectPrefab;
    public NodeUI nodeUI;

    private Node selectedNode;
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
    public bool EnounghMoney { get { return TurretToBuild.cost <= PlayerStats.money; } }
    public void SetTurretToBuild(TurretBlueprint turret)
    {
        TurretToBuild = turret;
        DeselectedNode();
    }

    
    
    public void SelectedNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectedNode();
            return;
        }
        selectedNode = node;
        TurretToBuild = null;

        nodeUI.SetTarget(node);
    }

    private void Start()
    {
        TurretToBuild = null;
    }

    public void DeselectedNode()
    {
        nodeUI.Hide();
        selectedNode = null;
    }

    public TurretBlueprint getTurretToBuild()
    {
        return TurretToBuild;
    }
}

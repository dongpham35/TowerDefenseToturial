using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NodeUI : MonoBehaviour
{
    private Node target;


    public Text txtUpgrade;
    public Button btnUpgrade;
    public Text txtSell;
    public Button btnSell;
    public GameObject ui;

    public void SetTarget(Node _target)
    {
        this.target = _target;
        transform.position = target.GetBuildPosition();
        ui.SetActive(true);
        if (!target.isUpgrade)
        {
            txtUpgrade.text = "$" + target.turretBluePrint.costUpgrade;
            btnUpgrade.interactable = true;
        }
        else
        {
            txtUpgrade.text = "DONE!";
            btnUpgrade.interactable = false;
        }
        txtSell.text = "$" + target.turretBluePrint.SellAmount(target.isUpgrade);
    }

    public  void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.Instance.DeselectedNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.Instance.DeselectedNode();
    }
}

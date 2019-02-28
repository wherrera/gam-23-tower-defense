using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlatform : MonoBehaviour
{
    public Tower tower;

    void OnMouseDown()
    {
        tower.gameObject.SetActive(true);
    }
}
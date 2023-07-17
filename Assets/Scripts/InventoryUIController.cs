using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIController : MonoBehaviour
{
    [SerializeField] private int cellSize;
    [SerializeField] private Cell cellPrefab;
    private Cell[] cells;

    private void Init()
    {
        cells = new Cell[cellSize];
        for (int i = 0; i < cells.Length; i++)
        {
            cells[i] = Instantiate(cellPrefab, gameObject.transform);
        }
        //cellPrefab.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        if(cells == null || cells.Length <= 0)
            Init();
        var inventory = GameManager.Instance.inventory;
        for (int i = 0; i < inventory.Items.Count; i++)
        {
            if(i < cells.Length)
                cells[i].Init(inventory.Items[i]);
        }
    }
}

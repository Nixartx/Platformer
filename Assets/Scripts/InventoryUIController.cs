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
            cells[i].OnUpdateCell += UpdateInventory;
        }
    }

    private void OnEnable()
    {
        if(cells == null || cells.Length <= 0)
            Init();
        UpdateInventory();
    }

    private void UpdateInventory()
    {
        var inventory = GameManager.Instance.inventory;

        foreach (var cell in cells)
            cell.Init(null);
        
        for (int i = 0; i < inventory.Items.Count; i++)
        {
            if(i < cells.Length)
                cells[i].Init(inventory.Items[i]);
        }
    }
}

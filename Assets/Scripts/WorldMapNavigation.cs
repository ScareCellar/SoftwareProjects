using UnityEngine;
using UnityEngine.EventSystems; // Required for EventSystem
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class PopupManager : MonoBehaviour
{
    public GameObject popupUIPrefab;
    public Canvas parentCanvas;
    public Tilemap targetTilemap;
    [Header("Allowed Sprites")]
    public Sprite[] allowedSprites; 
    [Header("Popup Settings")]
    public Vector2 popupOffset = new Vector2(150f, 0f);
    private GameObject activePopup;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPosition = targetTilemap.WorldToCell(worldPoint);

            TileBase clickedTile = targetTilemap.GetTile(cellPosition);

            if (clickedTile is Tile tile && IsAllowedSprite(tile.sprite))
            {
                ShowPopupAtCell(cellPosition);
            }
        }
    }

    bool IsAllowedSprite(Sprite sprite)
    {
        foreach (Sprite s in allowedSprites)
        {
            if (s == sprite)
                return true;
        }
        return false;
    }

    void ShowPopupAtCell(Vector3Int cellPos)
    {
        if (activePopup != null)
            Destroy(activePopup);

        Vector3 worldTileCenter = targetTilemap.GetCellCenterWorld(cellPos);
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldTileCenter);

        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentCanvas.transform as RectTransform,
            screenPos,
            parentCanvas.worldCamera,
            out localPoint
        );

        localPoint += popupOffset;

        activePopup = Instantiate(popupUIPrefab, parentCanvas.transform);
        activePopup.GetComponent<RectTransform>().anchoredPosition = localPoint;
    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }
}

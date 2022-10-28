using System;
using UnityEngine;

public class BoardItemSpawner : MonoBehaviour
{
    [SerializeField] private OnboardItem[] _onboardItemsPrefabs;
    [SerializeField] private GameObject _board;
    public void CreateItem(Type type, Vector2 itemPosition)
    {
        foreach(OnboardItem itemPrefab in _onboardItemsPrefabs)
        {
            if(itemPrefab.GetType() == type)
            {
                Spawnitem(itemPrefab, itemPosition);
                return;
            }
        }

    }
    private void Spawnitem(OnboardItem itemPrefab, Vector2 itemPosition) 
    {
        OnboardItem item = Instantiate(itemPrefab);
        item.transform.parent = _board.transform;
        item.transform.localPosition = itemPosition;
        item.transform.localScale = Vector3.one;
    }

}

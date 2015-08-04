using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class GenericGameItem
{
    public GameObject GameItem;
    public Stack ItemList;
    public int PreloadListSize;
    public bool Resizable;
}

public class MultiObjectManagement : MonoBehaviour
{
    public static MultiObjectManagement current;
    public List<GenericGameItem> GameItemList = new List<GenericGameItem>();

    void Awake()
    {
        current = this;
    }

    void Start()
    {
        for (int k = 0; k < GameItemList.Count; k++)
        {
            GameItemList[k].ItemList = new Stack();

            for (int m = 0;m < GameItemList[k].PreloadListSize;m++)
            {
                GameObject clone = Instantiate(GameItemList[k].GameItem) as GameObject;
                clone.SetActive(false);
                GameItemList[k].ItemList.Push(clone);
            }
        }
    }

    public void SpawnGameItem(int index)
    {
        if (GameItemList[index].ItemList.Count > 0)
        {
            GameObject ListItem = GameItemList[index].ItemList.Pop() as GameObject;
            ListItem.SetActive(true);
            ListItem.transform.position = GameItemList[index].GameItem.transform.position;
        }

        else if (GameItemList[index].Resizable == true)
        {
            GameObject InstantiatedClone = Instantiate(GameItemList[index].GameItem) as GameObject;
            InstantiatedClone.SetActive(true);
            InstantiatedClone.transform.position = GameItemList[index].GameItem.transform.position;
        }
    }

    public void DeactivateGameItem(GameObject deactivated, int index)
    {
        deactivated.SetActive(false);
        GameItemList[index].ItemList.Push(deactivated);
    }
}
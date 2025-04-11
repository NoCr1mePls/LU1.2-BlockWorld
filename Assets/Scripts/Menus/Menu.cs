using Dtos;
using Helpers;
using System;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// The script for the menu and its children.
/// </summary>
public class Menu : MonoBehaviour
{
    public GameObject[] prefabs;
    public List<GameObject> spawnedItems;
    public List<Object2DDto> object2Ds;

    private void Start()
    {
        object2Ds = new List<Object2DDto>();
    }
    /// <summary>
    /// Spawns a new item from an array.
    /// </summary>
    /// <param name="index">The index of the item in the array</param>
    public void SpawnObjectByID(int index)
    {
        if (index < prefabs.Length)
        {
            GameObject instance = Instantiate(prefabs[index], Helper.GetMousePosition2D(), Quaternion.identity);
            Draggable draggable = instance.GetComponent<Draggable>();
            draggable.isDragging = true;
            draggable.menu = this.gameObject;
            spawnedItems.Add(instance);
            object2Ds.Add(new Object2DDto
            {
                Id = Guid.NewGuid(),
                PrefabId = index,
                //PositionX = Helper.GetMousePosition2D().x, SET POSITIONX IN SAVE METHOD
                //PositionY = Helper.GetMousePosition2D().y, SET POSITIONY IN SAVE METHOD
                ScaleX = instance.transform.localScale.x,
                ScaleY = instance.transform.localScale.y,
                RotationZ = instance.transform.localRotation.z,
                SortingLayer = instance.layer,
                Environment2DId = EnvironmentHolder.currentEnvironment.Id
            });
        }
        else new Exception("Out of bounds index");
    }

    /// <summary>
    /// Undo's all objects.
    /// </summary>
    public void ResetCanvas()
    {
        for (int i = spawnedItems.Count; i > 0; i--)
        {
            Undo();
        }
    }

    /// <summary>
    /// Undo's the most recent object creation.
    /// </summary>
    public void Undo()
    {
        if (spawnedItems.Count > 0)
        {
            int newestIndex = spawnedItems.Count - 1;
            Destroy(spawnedItems[newestIndex]);
            spawnedItems.Remove(spawnedItems[newestIndex]);
            object2Ds.Remove(object2Ds[newestIndex]);
        }
    }

    public void Save()
    {
        for (int i = 0; i < object2Ds.Count; i++)
        {
            object2Ds[i].PositionX = spawnedItems[i].transform.localPosition.x;
            object2Ds[i].PositionY = spawnedItems[i].transform.localPosition.y;
        }
        ApiCallHelper.StoreEnvironment(object2Ds.ToArray());
    }
}
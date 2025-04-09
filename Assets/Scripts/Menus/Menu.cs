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
        }
    }

    public void Save()
    {
        //Save logic
        throw new NotImplementedException();
    }
}
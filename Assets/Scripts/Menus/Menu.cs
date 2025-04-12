using Dtos;
using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;


/// <summary>
/// The script for the menu and its children.
/// </summary>
public class Menu : MonoBehaviour
{
    public GameObject[] prefabs;
    public List<GameObject> spawnedItems;
    public List<Object2DDto> object2Ds;

    async void Start()
    {
        object2Ds = new List<Object2DDto>(await ApiCallHelper.GetObjects());
        foreach (Object2DDto dto in object2Ds)
        {
            SpawnObjectByID(dto.PrefabId, new Vector3(dto.PositionX, dto.PositionY, 0));
        }
    }
    /// <summary>
    /// Updates the menu's active state based on the dragging state of all spawned items.
    /// </summary>
    public void UpdateMenuState()
    {
        bool anyDragging = spawnedItems.Any(item => item.GetComponent<Draggable>().isDragging);
        this.gameObject.SetActive(!anyDragging);
    }

    public void SpawnObjectByID(int index)
    {
        if (index < prefabs.Length)
        {
            GameObject instance = Instantiate(prefabs[index], Helper.GetMousePosition2D(), Quaternion.identity);
            Draggable draggable = instance.GetComponent<Draggable>();
            draggable.isDragging = true;
            draggable.menuController = this;
            spawnedItems.Add(instance);
            object2Ds.Add(new Object2DDto
            {
                Id = Guid.NewGuid(),
                PrefabId = index,
                ScaleX = instance.transform.localScale.x,
                ScaleY = instance.transform.localScale.y,
                RotationZ = instance.transform.localRotation.z,
                SortingLayer = instance.layer,
                Environment2DId = EnvironmentHolder.currentEnvironment.Id
            });

            UpdateMenuState();
        }
        else
        {
            throw new Exception("Out of bounds index");
        }
    }

    public void SpawnObjectByID(int index, Vector3 position)
    {
        if (index < prefabs.Length)
        {
            GameObject instance = Instantiate(prefabs[index], position, Quaternion.identity);
            Draggable draggable = instance.GetComponent<Draggable>();
            draggable.isDragging = false;
            draggable.menuController = this;
            spawnedItems.Add(instance);

            UpdateMenuState();
        }
        else
        {
            throw new Exception("Out of bounds index");
        }
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
        ApiCallHelper.Store2DObjects(object2Ds.ToArray());
    }
}
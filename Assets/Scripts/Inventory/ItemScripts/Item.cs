using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public string itemName;
    public string description;
    public Sprite sprite;
    public Dictionary<string, int> stats = new Dictionary<string, int>();

    public enum ItemType { Tool, Resource, Food, Seed, Special};
    public ItemType type;

}

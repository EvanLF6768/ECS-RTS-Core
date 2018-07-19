using UnityEngine;

public class WorldData : MonoBehaviour
{
    public static WorldData worldData;

    public void Awake()
    {
        
    }

    public Sprite defaultTexture;
    public UIData[] uiData;
    public Building[] buildings;
    public Worker[] workers;
    public Player[] players;
}
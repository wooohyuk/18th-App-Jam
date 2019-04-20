using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class FishManager : MonoBehaviour
{
    public List<GameObject> fishPrefabs;
    public List<Transform> instantiateLocations;
    public Transform fishRootTrans;
    public int initialFishCount = 5;
    private void Awake()
    {
        fishRootTrans = this.transform;
    }

    private void Start()
    {
        initFishes();
    }

    void initFishes()
    {
        for (int i = 0; i < initialFishCount; i++)
        {
            instanciateRandomFish();
        }
    }

    public FishBehaviour instanciateRandomFish()
    {
        var loc = getRandomLocation();
        var fishPrefab = getRandomFishPrefab();
        var obj = Instantiate(fishPrefab, loc.position, Quaternion.identity);
        var fish = obj.GetComponent<FishBehaviour>();
        return fish;
    }

    GameObject getRandomFishPrefab()
    {
        var i = Random.Range(0, fishPrefabs.Count);
        return fishPrefabs[i];
    }


    Transform getRandomLocation()
    {
        var i = Random.Range(0, instantiateLocations.Count);
        return instantiateLocations[i];
    }
}

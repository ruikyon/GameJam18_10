using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour {
    public static FoodManager instance;
    [SerializeField]
    private Food[] foodsPrefabs;
    [SerializeField]
    private int interval;
    private int counter = 0;
    public int foodCount = 0;

	// Use this for initialization
	void Start () {
        instance = this;
        for (int i = 0; i < 30; i++)
        {
            var x = Random.Range(Field.min, Field.max);
            var y = Random.Range(Field.min, Field.max);
            Instantiate(foodsPrefabs[GetIndex()], new Vector3(x, y, 0), transform.rotation);
            foodCount++;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (foodCount >= 50) return;
        counter++;
        if (counter != interval) return;
        counter = 0;
        var x = Random.Range(Field.min, Field.max);
        var y = Random.Range(Field.min, Field.max);
        Instantiate(foodsPrefabs[GetIndex()], new Vector3(x, y, 0), transform.rotation);
        foodCount++;
    }

    private int GetIndex()
    {
        var p = Random.Range(0f, 1f);
        int index;
        if (p < 0.4) index = 0;
        else if (p < 0.7) index = 1;
        else if (p < 0.9) index = 2;
        else index = 3;

        return index;
    }
}

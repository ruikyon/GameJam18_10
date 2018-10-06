using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour {
    public static int min, max;

    [SerializeField]
    private int width;
    [SerializeField]
    private GameObject linePrefab;
    [SerializeField]
    Transform lines;

	void Awake () {
        GameObject temp;
        transform.localScale = new Vector3(width, width, 1);
        temp = Instantiate(linePrefab, Vector3.zero, Quaternion.Euler(0, 0, 0));
        temp.transform.localScale = new Vector3(0.05f, width, 1);
        temp.transform.parent = lines;
        temp = Instantiate(linePrefab, Vector3.zero, Quaternion.Euler(0, 0, 90));
        temp.transform.localScale = new Vector3(0.05f, width, 1);
        temp.transform.parent = lines;

        for (int i = 2; i*2 <= width; i += 2)
        {
            temp = Instantiate(linePrefab, new Vector3(i, 0, 0), Quaternion.Euler(0, 0, 0));
            temp.transform.localScale = new Vector3(0.05f, width, 1);
            temp.transform.parent = lines;
            temp = Instantiate(linePrefab, new Vector3(-i, 0, 0), Quaternion.Euler(0, 0, 0));
            temp.transform.localScale = new Vector3(0.05f, width, 1);
            temp.transform.parent = lines;
            temp = Instantiate(linePrefab, new Vector3(0, i, 0), Quaternion.Euler(0, 0, 90));
            temp.transform.localScale = new Vector3(0.05f, width, 1);
            temp.transform.parent = lines;
            temp = Instantiate(linePrefab, new Vector3(0, -i, 0), Quaternion.Euler(0, 0, 90));
            temp.transform.localScale = new Vector3(0.05f, width, 1);
            temp.transform.parent = lines;
        }

        min = -width / 2;
        max = width / 2;
	}
}

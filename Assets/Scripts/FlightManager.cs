using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightManager : MonoBehaviour

{
  public GameObject fireFlyPrefab;
  public int numFireFly = 20;
  public GameObject[] allFly;
  public Vector3 flightLimits = new Vector3(5f, 5f, 5f);
  [Header("Flight Settings")]
  [Range(0.0f, 5.0f)]

  public float minSpeed;
  [Range(0.0f, 5.0f)]
  public float maxSpeed;
  [Range(1.0f, 10.0f)]
  public float neighborDistance;
  [Range(0.0f, 5.0f)]
  public float rotationSpeed;

  // Start is called before the first frame update
  void Start()
  {
    allFly = new GameObject[numFireFly];
    for (int i = 0; i < numFireFly; i++)
    {
      Vector3 pos = this.transform.position + new Vector3(Random.Range(-flightLimits.x, flightLimits.x), Random.Range(-flightLimits.y, flightLimits.y), Random.Range(-flightLimits.z, flightLimits.z));
      allFly[i] = (GameObject)Instantiate(fireFlyPrefab, pos, Quaternion.identity);
      allFly[i].GetComponent<Flight>().myManager = this;
    }
  }

  // Update is called once per frame
  void Update()
  {

  }
}

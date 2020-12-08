using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class LabwareGenerator : MonoBehaviour
{
    [SerializeField,Range(0, 10)] public int lineA, lineB;
    [SerializeField] Transform spawnPoint;
    [SerializeField, Range(0, 2)] float offset = 1;
    [SerializeField] GameObject cylinderTemplate;
    [SerializeField] List<GameObject> listOfCylinders;
    [SerializeField] GameObject baseCube;
    [SerializeField] InputField a, b; 
    private void Start()
    {
        listOfCylinders = new List<GameObject>();
      
    }

    private void Update()
    {
       
    }

    public void ShowMustGoOn()
    {
        lineA = System.Convert.ToInt32(a.text);
        lineB = System.Convert.ToInt32(b.text);
        CleanScene();
        GenerateCylindersMatrix(lineA, lineB);
        GenerateBaseCube(); 
    }

    public void GenerateCylindersMatrix(int a, int b)
    {
        for(int i =0;i<a;i++)
        {
            for (int j = 0; j < b; j++)
            {
                Vector3 positionForSpawn = new Vector3(i, spawnPoint.position.y + 1, j);
                GameObject newOne = Instantiate(cylinderTemplate, positionForSpawn, Quaternion.identity);
                listOfCylinders.Add(newOne);
            }
        }
            
    }

    public void GenerateBaseCube()
    {
        baseCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        float avgX, avgZ, avgY;

        avgX = listOfCylinders.Average(cylinder => cylinder.transform.position.x);

        avgZ = listOfCylinders.Average(cylinder => cylinder.transform.position.z);

        avgY = spawnPoint.position.y;

        Debug.Log(avgX + ", " + avgY + ", " + avgZ);

        baseCube.transform.position = new Vector3(avgX,avgY, avgZ);
        baseCube.transform.localScale = new Vector3(lineA + 1, 1, lineB + 1);
    }
    public void CleanScene()
    {
        foreach(MeshFilter obj in GameObject.FindObjectsOfType<MeshFilter>())
        {
            Destroy(obj.gameObject);
        }
        listOfCylinders.Clear();
     
    }

    public  GameObject GetCubeObjectInstance()
    {
        return baseCube;
    }

    public List<GameObject> GetCylinders()
    {
        if (listOfCylinders.Count > 0)
            return listOfCylinders;
        else
            return null; // суперкод
    }
}

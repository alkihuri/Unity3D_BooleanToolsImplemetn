using Parabox.CSG.Demo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolleanOperationImplemetn : MonoBehaviour
{
     public void MakeUnitonCylinderOperation( )
    {
        GetComponent<Demo>().right = GetComponent<LabwareGenerator>().GetCubeObjectInstance();
        List<GameObject> listOfCylinders = GetComponent<LabwareGenerator>().GetCylinders();



        foreach(GameObject left in listOfCylinders)
        {
            GetComponent<Demo>().left = left;
            GetComponent<Demo>().SubtractionRLWithoutReset();
            GetComponent<Demo>().right = GetComponent<Demo>().composite;
        }
    }
     
    private void Update()
    {
         
    }
}

using Parabox.CSG.Demo;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolleanOperationImplemetn : MonoBehaviour
{
     public void MakeSubCylinderOperation( )
    {
       
        List<GameObject> listOfCylinders = GetComponent<LabwareGenerator>().GetCylinders();

        GetComponent<Demo>().right = listOfCylinders[0];

        for (int i =0;i<listOfCylinders.Count-1;i++)
        {
            MakeUnion(listOfCylinders[i],listOfCylinders[i+1]);
        }

        GetComponent<Demo>().left = GetComponent<Demo>().composite;

        GetComponent<Demo>().right = GetComponent<LabwareGenerator>().GetCubeObjectInstance();

        GetComponent<Demo>().SubtractionRLWithoutReset();
    }

    private void MakeUnion(GameObject right, GameObject left)
    {
        GetComponent<Demo>().left = left;        
        GetComponent<Demo>().UnionWithoutReset();
        Debug.LogWarning(left.name + " / " + GetComponent<Demo>().right.name + " was union");
        GetComponent<Demo>().right = GetComponent<Demo>().composite;
    }

     
     
}

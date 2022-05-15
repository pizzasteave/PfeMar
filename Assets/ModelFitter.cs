using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelFitter : MonoBehaviour
{
    public GameObject model;
    public GameObject modelZone;
   
    // Start is called before the first frame update
    void Start()
    {

        model = test.chosenModel;

        var x = Instantiate(model);

        var rot = x.AddComponent<Rotate>();
        rot.rotation.y = 1;

        StartCoroutine(MatchModelScaleWithGrid(x, modelZone));
    }

    IEnumerator MatchModelScaleWithGrid(GameObject model, GameObject modelZone)
    {
        var totalRenders = model.GetComponentsInChildren<Renderer>();
        var BoundsZone = modelZone.GetComponentInChildren<Collider>().bounds;

        //accumulate bounds from the object 
        var boundsOfModel = totalRenders[0].bounds;
        foreach (var c in totalRenders)
            boundsOfModel.Encapsulate(c.bounds);

        //get bounds size
        var szBoundsZone = BoundsZone.size;
        var szBoundsModel = boundsOfModel.size;

        //create Parent and place it at the <center> of the model 
        GameObject parent = new GameObject();

        parent.transform.position = boundsOfModel.center;
        model.transform.parent = parent.transform;

        //rational that fits with the zone 
        var scale = new Vector3(szBoundsZone.x / szBoundsModel.x, szBoundsZone.y / szBoundsModel.y, szBoundsZone.z / szBoundsModel.z);
        float minimumNewSizeRatio = Math.Max(scale.x, Math.Max(scale.y, scale.z));

        parent.transform.localScale *= minimumNewSizeRatio;

        parent.transform.position = modelZone.transform.position;


        yield return null;
    }


}



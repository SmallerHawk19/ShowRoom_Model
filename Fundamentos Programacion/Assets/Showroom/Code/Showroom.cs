using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Showroom : MonoBehaviour
{
    public GameObject Model;

    private Vector3 InitialScale;
    private Vector3 InitialPosition;
    private Vector3 InitialRotation;

    public GameObject Subject1;
    public GameObject Subject2;
    public GameObject Subject3;
    public GameObject Subject4;
    public GameObject Subject5;
    public GameObject Subject6;
    public GameObject Subject7;
    public GameObject Subject8;
    public GameObject Subject9;



    void Start()
    {
        InitialScale = Model.transform.localScale;
        InitialPosition = Model.transform.position;
        InitialRotation = Model.transform.rotation.eulerAngles;
    }

    public void Reset()
    {
        Model.transform.localScale = InitialScale;
        Model.transform.position = InitialPosition;
        Model.transform.rotation = Quaternion.Euler(InitialRotation);
    }

    public void RotateX(float angle)
    {
        Model.transform.Rotate(angle, 0, 0);
    }

    public void RotateY(float angle)
    {
        Model.transform.Rotate(0, angle, 0);
    }

    public void RotateZ(float angle)
    {
        Model.transform.Rotate(0, 0, angle);
    }

    public void MoveX(float distance)
    {
        Model.transform.Translate(distance, 0, 0);
    }

    public void MoveY(float distance)
    {
        Model.transform.Translate(0, distance, 0);
    }

    public void MoveZ(float distance)
    {
        Model.transform.Translate(0, 0, distance);
    }

    public void ScaleX(float scale)
    {
        Model.transform.localScale = new Vector3(Model.transform.localScale.x + scale, Model.transform.localScale.y, Model.transform.localScale.z);
    }

    public void ScaleY(float scale)
    {
        Model.transform.localScale = new Vector3(Model.transform.localScale.x, Model.transform.localScale.y + scale, Model.transform.localScale.z);
    }

    public void ScaleZ(float scale)
    {
        Model.transform.localScale = new Vector3(Model.transform.localScale.x, Model.transform.localScale.y, Model.transform.localScale.z + scale);
    }

    public void ActivateObj(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void DeActivateObj(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void ChangeMaterial(Material mat)
    {
        Subject1.GetComponent<MeshRenderer>().material = mat;
        Subject2.GetComponent<MeshRenderer>().material = mat;
        Subject3.GetComponent<MeshRenderer>().material = mat;
        Subject4.GetComponent<MeshRenderer>().material = mat;
        Subject5.GetComponent<MeshRenderer>().material = mat;
        Subject6.GetComponent<MeshRenderer>().material = mat;
        Subject7.GetComponent<MeshRenderer>().material = mat;
        Subject8.GetComponent<MeshRenderer>().material = mat;
        Subject9.GetComponent<MeshRenderer>().material = mat;

    }

    
}

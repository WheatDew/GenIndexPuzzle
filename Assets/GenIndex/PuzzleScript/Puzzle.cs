using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public string codeString;

    public float width;

    private void Start()
    {
        width = transform.localScale.z;
    }

    public List<Transform> puzzleParts=new List<Transform>();
    public List<List<Puzzle>> puzzleChild = new List<List<Puzzle>>();

    public void Insert(int positionNumber,Puzzle part)
    {
        UpdatePositionOnAddition(positionNumber, part.width);
        puzzleChild[positionNumber].Add(part);
        part.transform.position = puzzleParts[positionNumber * 2 - 1].position + new Vector3(0.6f, 0, 0);
        
    }

    public void UpdatePositionOnAddition(int positionNumber,float width)
    {
        int convertNumber = positionNumber * 2-1;
        for(int i = 0; i < convertNumber; i++)
            puzzleParts[i].transform.position += new Vector3(0, 0, width);
        puzzleParts[convertNumber].localScale += new Vector3(0,0,width*0.1f);
    }

}

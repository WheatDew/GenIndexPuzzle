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

    public void TestInsert(Puzzle puzzle)
    {
        Insert(1, puzzle);
    }

    public void Insert(int positionNumber,Puzzle part)
    {
        int convertNumber = positionNumber * 2 - 1;
        UpdatePositionOnAddition(convertNumber, part.width);
        puzzleChild[convertNumber].Add(part);
        part.transform.position = puzzleParts[convertNumber].position + new Vector3(0.6f, 0, 0);
    }

    public void UpdatePositionOnAddition(int convertNumber, float width)
    {
        
        for(int i = 0; i < convertNumber; i++)
            puzzleParts[i].transform.position += new Vector3(0, 0, width);
        puzzleParts[convertNumber].localScale += new Vector3(0,0,width*0.1f);
    }

}

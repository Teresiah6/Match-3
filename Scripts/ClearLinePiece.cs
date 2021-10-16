using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearLinePiece : ClearableScript
{
    public bool isRow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Clear()
    {
        base.Clear();

        if (isRow)
        {
            //clear row
            piece.GridrefScript.ClearRow(piece.Y);
        }
        else
        {
            //clear column
            piece.GridrefScript.ClearColumn(piece.X);

        }
    }
}

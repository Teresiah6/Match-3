using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePiece : MonoBehaviour
{
    public int score;
    private int x;
    private int y;
    
    public int X
    {
        get { return x; }
        set {  if (IsMovable())
                x = value;
        }
    }
    public int Y
    {
        get { return y; }
        set
        {
            if (IsMovable())
                y = value;
        }
    }
    private GridRefScript.PieceType type;
    public GridRefScript.PieceType Type
    {
        get { return type; }
    }
    //reference to gridrefscript if we need other information
    private GridRefScript gridRefScript;
    public GridRefScript GridrefScript
    {
        get { return gridRefScript; }
    }
    private MovablePiece movableComponent;
    public MovablePiece MovableComponent
    {
        get { return movableComponent; }
    }

    private ColorPiece colorComponent;
    public ColorPiece ColorComponent
    {
        get { return colorComponent; }
    }
    private ClearableScript clearableComponent;
    public ClearableScript ClearableComponent
    {
        get { return clearableComponent; }
    }
    private void Awake()
    {
        movableComponent = GetComponent<MovablePiece>();
        colorComponent = GetComponent<ColorPiece>();
        clearableComponent = GetComponent<ClearableScript>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Init(int _x, int _y, GridRefScript _gridRefScript, GridRefScript.PieceType _type)
    {
        x = _x;
        y = _y;
        gridRefScript = _gridRefScript;
        type = _type;
    }

    void OnMouseEnter()
    {
        gridRefScript.EnterPiece(this);
        
    }
     void OnMouseDown()
    {
        gridRefScript.PressPiece(this);

        
    }
     void OnMouseUp()
    {
        gridRefScript.ReleasePiece();
    }
    public bool IsMovable()
    {
        return movableComponent != null;
    }
    public bool IsColored()
    {
        return colorComponent != null;
    }
    public bool IsClearable()
    {
        return clearableComponent != null;
    }
}

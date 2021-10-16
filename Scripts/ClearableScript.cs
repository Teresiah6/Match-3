using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearableScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AnimationClip clearAnimation;
    private bool isBeingCleared = false;

    public bool IsBeingCleared
    {
        get { return isBeingCleared; }
    }
    protected GamePiece piece;

    void Awake()
    {
        piece = GetComponent<GamePiece>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //for use by others
    public virtual void Clear()
    {
        piece.GridrefScript.level.OnPieceCleared(piece);
        isBeingCleared = true;
        StartCoroutine(ClearCoroutine());
    }
    private IEnumerator ClearCoroutine()
    {
        Animator animator = GetComponent<Animator>();

        if (animator)
        {
            animator.Play(clearAnimation.name);      
            yield return new WaitForSeconds(clearAnimation.length);
            //once finished playing the animation ,destroy piece
            Destroy(gameObject);
        }
    }
}

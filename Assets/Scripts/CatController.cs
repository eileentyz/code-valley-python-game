using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CatController : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer catSpriteRenderer;
    public List<CatType> catTypes = new List<CatType>();
    public float moveSpeed = 2f;
    public Vector2 roomMin, roomMax;

    private int currentCatIndex = 0;
    private Vector3 targetPosition;
    private bool isMoving = false;

    void Start()
    {
        PickNewCatType();
        PickNewAction();
        InvokeRepeating("PickNewCatType", 60f, 60f);
    }

    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
                PlayAnimation("Idle");
                Invoke("PickNewAction", UnityEngine.Random.Range(2f, 5f));
            }
        }
    }

    void PickNewAction()
    {
        int action = UnityEngine.Random.Range(0, 3);

        if (action == 0 && catTypes[currentCatIndex].canWalk)
        {
            targetPosition = new Vector3(
                UnityEngine.Random.Range(roomMin.x, roomMax.x),
                UnityEngine.Random.Range(roomMin.y, roomMax.y),
                transform.position.z
            );

            catSpriteRenderer.flipX = targetPosition.x < transform.position.x;
            isMoving = true;
            PlayAnimation("Walk");
        }
        else if (action == 1)
        {
            PlayAnimation("Lick");
            Invoke("PickNewAction", UnityEngine.Random.Range(2f, 4f));
        }
        else
        {
            PlayAnimation("Sleep");
            Invoke("PickNewAction", UnityEngine.Random.Range(4f, 8f));
        }
    }

    void PlayAnimation(string name)
    {
        animator.Play(name);
    }

    void PickNewCatType()
    {
        int newIndex = UnityEngine.Random.Range(0, catTypes.Count);
        SwitchCatType(newIndex);
        PickNewAction();
    }

    void SwitchCatType(int index)
    {
        currentCatIndex = index;
        CatType type = catTypes[index];
        catSpriteRenderer.sprite = type.catSprite;
        animator.runtimeAnimatorController = type.animatorController;
    }
}

[System.Serializable]
public class CatType
{
    public string name;
    public Sprite catSprite;
    public bool canWalk;
    public RuntimeAnimatorController animatorController;
}

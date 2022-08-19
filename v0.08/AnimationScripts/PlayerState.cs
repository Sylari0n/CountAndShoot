using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    
    [SerializeField] float ballMultiplier = 3.0f;
    [SerializeField] GameObject _ballSpawnerObj;
    [SerializeField] GameObject _bag;
    [SerializeField] GameObject _bonusBall;
    
    void Start()
    {
        pAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (pAnimator != null)        
        {
            IdleToWalk();
            WalkToStack();
            StackToJump();
            IsCrouching();
            Finished();
            RunToDeath();
            
            BagHandler();

            AirHit();
            DirectHit();
            BottomHit();

        }
    }

    void BagHandler()
    {
        gameObject.GetComponent<PlayerControls>().bag.SetBlendShapeWeight(0,
            _ballSpawnerObj.GetComponent<BallScript>().totalBallCount * ballMultiplier); 
    }


    void IdleToWalk()
    {
            if (GetComponent<PlayerControls>().isTapped)
            {
                pAnimator.SetTrigger("IdleToWalk");
            }
    }

    void WalkToStack()
    {
        if (PlayerControls.isPressing && !GetComponent<PlayerControls>()._ballScript.GetComponent<BallScript>()._stackState) 
        {
            if (_ballSpawnerObj.GetComponent<BallScript>().totalBallCount > 0 )
            {
                pAnimator.SetTrigger("WalkToStack");
            }
        }
    }

    void StackToJump()
    {
        if (GetComponent<PlayerControls>()._ballScript.GetComponent<BallScript>()._stackState && !PlayerControls.isPressing)
        {
            pAnimator.SetTrigger("StackToJump");
            pAnimator.ResetTrigger("WalkToStack");
        }
    }

    void IsCrouching()
    {
        if (PlayerControls.isPressing)
        {
            pAnimator.SetBool("isCrouching", true);
        }
        else
        {
            pAnimator.SetBool("isCrouching", false);
        }
    }

    void Finished()
    {
        if (GetComponent<PlayerControls>().isFnished)
        {
            pAnimator.SetTrigger("Finished");
        }
    }


    // Ball Hit Animations
    void AirHit()
    {
        if (GetComponent<PlayerControls>()._airHitbox.GetComponent<AirHitbox>().isAir && PlayerControls.isPressed)
        {
            pAnimator.SetTrigger("AirHit");
            pAnimator.ResetTrigger("DirectHit");
            pAnimator.ResetTrigger("BottomHit");
            Invoke(nameof(ResetAir), 0.05f);
        }        
    }
    void ResetAir()
    {
        pAnimator.ResetTrigger("AirHit");
    }

    void DirectHit()
    {
        if (GetComponent<PlayerControls>()._directHitbox.GetComponent<DirectHitbox>().isDirect && PlayerControls.isPressed)
        {
            pAnimator.SetTrigger("DirectHit");
            pAnimator.ResetTrigger("AirHit");
            pAnimator.ResetTrigger("BottomHit");
            Invoke(nameof(ResetDirect), 0.05f);
        }
    }
    void ResetDirect()
    {
        pAnimator.ResetTrigger("DirectHit");
    }

    void BottomHit()
    {
        if (GetComponent<PlayerControls>()._bottomHitbox.GetComponent<BottomHitbox>().isBottom && PlayerControls.isPressed)
        {
            pAnimator.SetTrigger("BottomHit");
            pAnimator.ResetTrigger("AirHit");
            pAnimator.ResetTrigger("DirectHit");
            Invoke(nameof(ResetBottom), 0.05f);
        }
    }
    void ResetBottom()
    {
        pAnimator.ResetTrigger("BottomHit");
    }

    void RunToDeath()
    {
        if (gameObject.GetComponent<PlayerControls>().isEnemy)
        {
            pAnimator.SetTrigger("RunToDeath");
        }
    }



    // internal bool _airDone = false;
    // internal bool _directDone = false;
    // internal bool _bottomDone = false;
    private Animator pAnimator;    
}

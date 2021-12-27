using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameMachine : MonoBehaviour
{
   [SerializeField] private GameObject borderA;
   [SerializeField] private GameObject borderB;
   [SerializeField] private GameObject visual;
   [SerializeField] private Animation animation;
   [SerializeField] private Vector2 time;

   public UnityEvent OpenBorderAEvent;
   public UnityEvent OpenBorderBEvent;

   public void StartTime()
   {
      visual.SetActive(true);
      animation.Play();
      StartCoroutine(ShakeCor());
   }
   public void StopTime()
   {
      visual.SetActive(false);
      animation.Stop();
   }
   
   
   private  IEnumerator ShakeCor()
   {
      yield return new WaitForSeconds(Random.Range(time.x, time.y));

      if (Random.Range(0, 10) % 2 == 1) SetBorderA();
      else SetBorderB();
     
     

      StopTime();
   }

   public void SetBorderA()
   {
      borderA.SetActive(true);
      borderB.SetActive(false);
      OpenBorderAEvent?.Invoke();
   }
   public void SetBorderB()
   {
      borderA.SetActive(false);
      borderB.SetActive(true);
      OpenBorderBEvent?.Invoke();
   }
}

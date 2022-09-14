using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsView : MonoBehaviour
{
   [SerializeField] private TMP_Text stats;

   public TMP_Text Stats
   {
      get => stats;
      set => stats = value;
   }
}

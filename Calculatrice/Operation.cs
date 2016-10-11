using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculatrice
{
   abstract class Operation
   {
      protected float firstOperande;
      protected float secondOperande;
      protected float result;
      protected bool erreur;

      public float FirstOperande
      {
         get { return this.firstOperande; }
         set { this.firstOperande = value; }
      }

      public float SecondOperande
      {
         get { return this.secondOperande; }
         set { this.secondOperande = value; }
      }

      public float Result
      {
         get { return this.result; }
      }

      public bool Erreur
      {
         get { return this.erreur; }
      }

      public abstract void Calculate();
      public abstract override String ToString();
   }
}

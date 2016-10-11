using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculatrice
{
   class Division : Operation
   {
      public override void Calculate()
      {
         if (this.secondOperande != 0)
         {
            this.result = this.firstOperande / this.secondOperande;
            this.erreur = false;
         }
         else
         {
            this.erreur = true;
         }

      }

      public override string ToString()
      {
         return "/";
      }
   }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculatrice
{
   class Addition : Operation
   {
      public override void Calculate()
      {
         this.result = this.firstOperande + this.secondOperande;
         this.erreur = false;
      }

      public override String ToString()
      {
         return "+";
      }
   }
}

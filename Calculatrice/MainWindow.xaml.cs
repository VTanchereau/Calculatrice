using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculatrice
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      private String firstOperande;
      private String secondOperande;
      private Operation operation;
      private bool isFirstOperandeFinished;
      private bool calculDone;
      private String result;

      public MainWindow()
      {
         InitializeComponent();
         this.isFirstOperandeFinished = false;
         this.firstOperande = "";
         this.secondOperande = "";
         this.result = "";
         this.calculDone = false;

         historique.Text = "";
   }

      private void button_un_Click(object sender, RoutedEventArgs e)
      {
         this.AjouterEntreeEcran("1");
      }

      private void button_deux_Click(object sender, RoutedEventArgs e)
      {
         this.AjouterEntreeEcran("2");
      }

      private void button_trois_Click(object sender, RoutedEventArgs e)
      {
         this.AjouterEntreeEcran("3");
      }

      private void button_quatre_Click(object sender, RoutedEventArgs e)
      {
         this.AjouterEntreeEcran("4");
      }

      private void button_cinq_Click(object sender, RoutedEventArgs e)
      {
         this.AjouterEntreeEcran("5");
      }

      private void button_six_Click(object sender, RoutedEventArgs e)
      {
         this.AjouterEntreeEcran("6");
      }
      private void button_sept_Click(object sender, RoutedEventArgs e)
      {
         this.AjouterEntreeEcran("7");
      }

      private void button_huit_Click(object sender, RoutedEventArgs e)
      {
         this.AjouterEntreeEcran("8");
      }

      private void button_neuf_Click(object sender, RoutedEventArgs e)
      {
         this.AjouterEntreeEcran("9");
      }

      private void button_zero_Click(object sender, RoutedEventArgs e)
      {
         this.AjouterEntreeEcran("0");
      }

      private void button_effacer_Click(object sender, RoutedEventArgs e)
      {
         this.EffacerDerniereEntree();
      }

      private void button_virgule_Click(object sender, RoutedEventArgs e)
      {
         this.AjouterEntreeEcran(",");
      }

      private void button_plus_Click(object sender, RoutedEventArgs e)
      {
         AjouterOperationEcran(new Addition());
      }

      private void button_moins_Click(object sender, RoutedEventArgs e)
      {
         AjouterOperationEcran(new Soustraction());
      }

      private void button_multiplier_Click(object sender, RoutedEventArgs e)
      {
         AjouterOperationEcran(new Multiplication());
      }

      private void button_diviser_Click(object sender, RoutedEventArgs e)
      {
         AjouterOperationEcran(new Division());
      }

      private void button_egal_Click(object sender, RoutedEventArgs e)
      {
         this.CalculerResultat();
      }

      private void CalculerResultat()
      {
         if (this.secondOperande == "")
         {
            ecran_resultat.Text = "SECOND NOMBRE VIDE!";
         }
         else
         {
            this.operation.FirstOperande = float.Parse(this.firstOperande);
            this.operation.SecondOperande = float.Parse(this.secondOperande);
            this.operation.Calculate();
            if (!this.operation.Erreur)
            {
               this.result = this.operation.Result.ToString();
               ecran_resultat.Text = this.FormatNumber(this.result);
               this.calculDone = true;
               String histo;
               histo = " " + this.FormatNumber(this.firstOperande);
               histo += " " + this.operation.ToString();
               histo += " " +  this.FormatNumber(this.secondOperande);
               histo += " = " + this.FormatNumber(this.result); 

               if (historique.Text == "")
               {
                  historique.Text = " HISTORIQUE : ";
                  historique.Text += "\n";
               }
               historique.Text += "\n";
               historique.Text += histo;
            }
            else
            {
               ecran_resultat.Text = "DIVISION PAR ZERO!";
            }
         }
      }

      private void AjouterOperationEcran(Operation ope)
      {
         if (calculDone)
         {
            this.firstOperande = this.result;
            this.operation = ope;
            this.secondOperande = "";
            this.calculDone = false;
            this.EditerExpressionEcran();
         }
         else if (this.firstOperande == "")
         {
            ecran_resultat.Text = "PERMIER NOMBRE VIDE";
         }
         else if (!this.isFirstOperandeFinished)
         {
            this.operation = ope;
            this.isFirstOperandeFinished = true;
            this.EditerExpressionEcran();
         }
         else if (this.secondOperande != "")
         {
            this.CalculerResultat();
            this.operation = ope;
            this.calculDone = false;
            this.firstOperande = this.result;
            this.secondOperande = "";
            this.EditerExpressionEcran();
         }
         
      }

      private void AjouterEntreeEcran(String entree)
      {
         if (calculDone)
         {
            this.firstOperande = entree;
            this.operation = null;
            this.secondOperande = "";
            this.isFirstOperandeFinished = false;
            this.calculDone = false;
         }else if (this.isFirstOperandeFinished)
         {
            this.secondOperande += entree;
         }
         else
         {
            this.firstOperande += entree;
         }
         this.EditerExpressionEcran();
      }

      private void EffacerDerniereEntree()
      {
         if ((this.isFirstOperandeFinished)&&(this.secondOperande == ""))
         {
            this.operation = null;
            this.isFirstOperandeFinished = false;
            this.EditerExpressionEcran();
         }
         else if (this.isFirstOperandeFinished)
         {
            this.secondOperande = this.secondOperande.Remove(this.secondOperande.Length - 1, 1);
            this.EditerExpressionEcran();
         }
         else if (this.firstOperande != "")
         {
            this.firstOperande = this.firstOperande.Remove(this.firstOperande.Length - 1, 1);
            this.EditerExpressionEcran();
         }
         else
         {
            ecran_resultat.Text = "L'EXPRESSION EST VIDE";
         }
      }

      private void EditerExpressionEcran()
      {
         if (this.isFirstOperandeFinished && this.secondOperande != "")
         {
            ecran_expression.Text = this.FormatNumber(this.firstOperande) + this.operation.ToString() + this.FormatNumber(this.secondOperande);
         }
         else if (this.isFirstOperandeFinished)
         {
            ecran_expression.Text = this.FormatNumber(this.firstOperande) + this.operation.ToString();
         }
         else if (this.firstOperande != "")
         {
            ecran_expression.Text = this.FormatNumber(this.firstOperande);
         }
         else
         {
            ecran_expression.Text = "";
         }
      }

      private String FormatNumber(String str)
      {
         NumberFormatInfo nfi = new CultureInfo("fr-FR", false).NumberFormat;
         nfi.NumberDecimalDigits = 0;
         float nombre;
         nombre = float.Parse(str);

         return nombre.ToString("N", nfi);
      }

   }
}

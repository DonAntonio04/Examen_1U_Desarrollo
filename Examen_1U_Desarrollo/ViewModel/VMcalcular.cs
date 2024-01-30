using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Examen_1U_Desarrollo.ViewModel
{
    public class VMcalcular : BaseViewModel
    {
        #region VARIABLES
        double _peso;
   
        double _altura;
        double _resultado;
        double _latidos;
        #endregion
        #region CONSTRUCTOR
        public VMcalcular(INavigation navigation)
        {
            Navigation = navigation;    
        }
        #endregion
        #region OBJETOS
         public double Peso
        {
            get { return _peso; }
            set {SetValue(ref _peso, value); }
        }
        public double Latidos
        {
            get { return _latidos; }
            set
            {
                SetValue(ref _latidos, value);
            }
        }
        public double Altura
        {
            get { return _altura; }
            set { SetValue(ref _altura, value);}
        }
        public double Resultado
        {
            get { return _resultado; }
            set { SetValue(ref _resultado, value);} 
        }
        #endregion
        #region PROCESOS
        public void IMC(double peso, double altura)
        {
          Peso= peso;
         Latidos 

        }
        public void FCN(double latidos)
        {
            Latidos = latidos * 4;
            
        
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Examen_1U_Desarrollo.ViewModel
{
    public class VMcalcular : BaseViewModel
    {
        #region VARIABLES
        double _IMC1;
        bool _imc;
        bool _fcn;   
        bool _MostrarFcn;
        bool _Mostrarimc;
        bool _MostrarComprobar;
        bool _mostrarCrisis;
        double _altura;
        string _resultado;
        string _resultadoImc;
        double _latidos;
        #endregion
        #region CONSTRUCTOR
        public VMcalcular(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region OBJETOS
        public double IMC1
        {
            get { return _IMC1; }
            set { SetValue(ref _IMC1, value); }
        }
        public bool IMC
        {
            get { return _imc; }
            set
            {
                SetValue(ref _imc, value);
                if (_imc)
                {
                    MostrarFcn = false;  
                    MostrarImc = true;   
                }
            }
        }

        public bool FCN
        {
            get { return _fcn; }
            set
            {
                SetValue(ref _fcn, value);
                if (_fcn)
                {
                    MostrarImc = false;  
                    MostrarFcn = true;   
                }
            }
        }


        public bool MostrarFcn
        {
            get { return _MostrarFcn; }
            set { SetValue(ref _MostrarFcn, value); }
        }
        public bool MostrarImc
        {
            get { return _Mostrarimc; }
            set { SetValue(ref _Mostrarimc, value); }
        }

        public bool MostrarComprobar
        {
            get { return _MostrarComprobar; }
            set { SetValue(ref _MostrarComprobar, value); }
        }
        public bool MostrarCrisis
        {
            get { return _mostrarCrisis; }
            set {SetValue(ref  _mostrarCrisis, value); }
        }
        public double Latidos
        {
            get { return _latidos; }
           set { SetValue(ref _latidos, value); }
        }
        public double Altura
        {
            get { return _altura; }
            set { SetValue(ref _altura, value);}
        }
        public string ResultadoImc
        {
            get { return _resultadoImc; }
            set { SetValue(ref _resultadoImc, value);}
        }
        public string Resultado
        {
            get { return _resultado; }
            set { SetValue(ref _resultado, value);} 
        }
        #endregion
        #region PROCESOS
        public void CalcularIMC()
        {
            double A = 0;
            double B = 0;
            IMC1 = A / B * 2;
        }

        public void CalcularIMC1()
        {
           if(MostrarImc)
            {
               if(IMC1 < 18.5)
                {
                    ResultadoImc = $"Su IMC es {IMC1}, Usted tiene un peso insuficiente";
                    MostrarComprobar = false;
                    MostrarCrisis = false;
                }
               else if(IMC1 >= 18.5 && 24.9 <= IMC1)
                {
                    ResultadoImc = $"Su IMC es {IMC1}, Normal o saludable";
                    MostrarComprobar = true;
                    MostrarCrisis = false;
                }
               else if (IMC1 >= 25.0 && 29.9 <= IMC1 )
                {
                    ResultadoImc = $"Su IMC es {IMC1}, tiene SobrePeso";
                    MostrarComprobar = false;
                    MostrarCrisis = true;
                }
               else
                {
                    ResultadoImc = $"Su IMC es {IMC}, tiene Obesidad";
                    MostrarComprobar = false;
                    MostrarCrisis = false;
                }
            }
        }

        public void Calcularf(double a)
        {
           Latidos =  Latidos * 4;
            
        }

        public void CalcularFCN()
        {
            if (MostrarFcn)
            {
                
                Calcularf(Latidos);

                if (Latidos < 0)
                {
                    Resultado = $"Su IMC es {Latidos} Error";
                    MostrarComprobar = false;
                    MostrarCrisis = false;
                }
                else if (Latidos < 60)
                {
                    Resultado = $"Su FCN es {Latidos}Es Bajo";
                    MostrarComprobar = true;
                    MostrarCrisis = false;
                }
                else if (Latidos >= 60 && Latidos <= 100)
                {
                    Resultado = "Es Normal";
                    MostrarComprobar = true;
                    MostrarCrisis = false;
                }
                else
                {
                    Resultado = "Es Alta";
                    MostrarComprobar = false;
                    MostrarCrisis = true;
                }
            }
          
        }
      
        #endregion
        #region COMANDOS
        public ICommand CalcularCommand => new Command(CalcularFCN);
        public ICommand Calcularimccommand => new Command(CalcularIMC1);    
        #endregion
    }
}

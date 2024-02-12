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
        double _peso;
        double _altura;
        bool _MostrarFcn;
        bool _Mostrarimc;
        bool _MostrarComprobar;
        bool _mostrarCrisis; 
        string _resultado;
        string _resultado1;
        string _resultadoImc;
        double _latidos;
        double _latido;
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
        public double Latido
        {
            get { return _latido; }
            set { SetValue(ref _latido, value); }
        }
        public double Altura
        {
            get { return _altura; }
            set { SetValue(ref _altura, value);}
        }
        public double Peso
        {
            get { return _peso; }
            set { SetValue(ref _peso, value); }
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
        public string Resultado1
        {
            get { return _resultado1; }
            set { SetValue(ref _resultado1, value);}
        }
        #endregion
        #region PROCESOS
        public void CalcularIMC(double a, double p)
        {
            IMC1 = p / Math.Pow(a, 2);
        }

        public async void CalcularIMC1()
        {

            if (!string.IsNullOrEmpty(Convert.ToString(Peso)) && !string.IsNullOrEmpty(Convert.ToString(Altura)))
            {

                CalcularIMC(Altura,Peso);

                if (IMC1 < 18)
                {
                    ResultadoImc = $"Si IMC es {IMC1},Tienes bajo peso";
                }
                else if (IMC1 >= 18 && IMC1 <= 24.9)
                {
                    ResultadoImc = $"Su IMC es {IMC1},Peso Normal";
                }
                else if (IMC1 > 24.9 && IMC1 <= 29.9)
                {
                    ResultadoImc = $"Su IMC es {IMC1},Tienes Sobre Peso";
                }
                else
                {
                    ResultadoImc = $"Su IMC es {IMC1},Tienes Obesidad";
                }
            }
        }

        public void Calcularf(double a)
        {
           Latido =  a * 4;
            
        }

        public void CalcularFCN()
        {
            if (MostrarFcn)
            {
                
                Calcularf(Latidos);

                if (Latido < 0)
                {
                    Resultado1 = $"Su FCN es {Latido} Error";
                    MostrarComprobar = false;
                    MostrarCrisis = false;
                }
                else if (Latido < 60)
                {
                    Resultado1 = $"Su FCN es {Latido}, Es Bajo";
                    MostrarComprobar = true;
                    MostrarCrisis = false;
                }
                else if (Latido >= 60 && Latido <= 100)
                {
                    Resultado1 = $"Su FCN es {Latido}, Es Normal";
                    MostrarComprobar = true;
                    MostrarCrisis = false;
                }
                else
                {
                    Resultado1 = $"Su FCN es {Latido}, Es Alta";
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

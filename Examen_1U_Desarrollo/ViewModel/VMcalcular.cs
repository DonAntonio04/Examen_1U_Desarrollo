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
        double _peso;
        bool _imc;
        bool _fcn;   
        bool _MostrarFcn;
        bool _Mostrarimc;
        bool _MostrarComprobar;
        bool _mostrarCrisis;
        double _altura;
        string _resultado;
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
            set { SetValue(ref _peso, value); }
        }
        public bool IMC
        {
            get { return _imc; }
            set
            {
                SetValue(ref _imc, value);
                if (_imc)
                {
                    MostrarFcn = false;  // Ocultar la entrada de FCN si se selecciona IMC
                    MostrarImc = true;   // Mostrar la entrada de IMC si se selecciona IMC
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
                    MostrarImc = false;  // Ocultar la entrada de IMC si se selecciona FCN
                    MostrarFcn = true;   // Mostrar la entrada de FCN si se selecciona FCN
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
        public string Resultado
        {
            get { return _resultado; }
            set { SetValue(ref _resultado, value);} 
        }
        #endregion
        #region PROCESOS
        public void CalcularIMC()
        {

        }



        public void Calcularf(double a)
        {
            Latidos = a * 4;
        }

        public void CalcularFCN()
        {
            if (MostrarFcn)
            {
                // Lógica específica para FCN si es necesario
                Calcularf(Latidos);

                if (Latidos < 0)
                {
                    Resultado = "Error";
                    MostrarComprobar = false;
                    MostrarCrisis = false;
                }
                else if (Latidos < 60)
                {
                    Resultado = "Es Bajo";
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
     
        #endregion
    }
}

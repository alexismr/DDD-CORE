using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;

namespace UnitTests
{
   public class Alfanumerico
    {


        [Fact]
        public void ValidarPrefijo_ConEspacios_Al_Final()
        {
            var identificacion = "1234567890 ";
            string _value = identificacion.PadLeft(11, '0');
            string consts = "01234567890";
            Assert.Equal(_value, consts);
        }

    [Fact]
        public void ValidarPrefijo_ConEspacios_Al_Inicio()
        {
            var identificacion = " 1234567890";
            string _value = identificacion.PadLeft(11, '0');
            string consts = "01234567890";
            Assert.Equal(_value, consts);
        }

        [Fact]
        public void ValidarPrefijo_ConEspacios_Al_Intermedio()
        {
            var identificacion = "12345 67890";
            string _value = identificacion.PadLeft(11, '0');
            string consts = "01234567890";
            Assert.Equal(_value, consts);
        }


        [Fact]
        public void ValidarPrefijo_CambiarEspacios_Regex_Replace_Alfanumerico()
        {
            var identificacion = "1234567890";
            string _value = identificacion.PadLeft(11, '0');
            string consts = "01234567890";

            List<string> listSpaces = new List<string>();
            listSpaces.Add("1234567890 ");
            listSpaces.Add(" 1234567890");
            listSpaces.Add("123456789 0");
            listSpaces.Add("12345678 90");
            listSpaces.Add("1234567 890");
            listSpaces.Add("123456 7890");
            listSpaces.Add("12 34567890");
            listSpaces.Add("1 234567890");
       
          var newdata=   listSpaces[2].Replace(" ", string.Empty);
          foreach (var _item in listSpaces) Assert.Equal(Regex.Replace(_item, "[^0-9a-zA-Z]+", "").PadLeft(11, '0'), consts);

        }


        [Fact]
        public void ValidarPrefijo_CambiarEspacios_Regex_Replace_anumerico()
        {
            var identificacion = "1234567890";
            string _value = identificacion.PadLeft(11, '0');
            string consts = "01234567890";

            List<string> listSpaces = new List<string>();
            listSpaces.Add("1234567890 ");
            listSpaces.Add(" 1234567890");
            listSpaces.Add("123456789 0");
            listSpaces.Add("12345678 90");
            listSpaces.Add("1234567 890");
            listSpaces.Add("123456 7890");
            listSpaces.Add("12 34567890");
            listSpaces.Add("1 234567890a");

            var campo = Regex.Replace(listSpaces[7], "[^0-9]+", "").PadLeft(11, '0');



            //var newdata = listSpaces[2].Replace(" ", string.Empty);
            //foreach (var _item in listSpaces)  Assert.Equal(Regex.Replace(_item, "[^0-9]+", "").PadLeft(11, '0'), consts);
  

        }




    }
}

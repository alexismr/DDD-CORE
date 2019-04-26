using System;
using Xunit;

namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void ValidarPrefijo_11_Numeros()
        {
            var identificacion = "12345678901";
            string _value = identificacion.PadLeft(11, '0');
            string consts = "12345678901";
            Assert.Equal(_value, consts);
        }


        [Fact]
        public void ValidarPrefijo_10_numeros()
        {
            var identificacion = "1234567890";
            string _value = identificacion.PadLeft(11, '0');
            string consts = "01234567890";
            Assert.Equal(_value, consts);

        }


        [Fact]
        public void ValidarPrefijo_9_numeros()
        {
            var identificacion = "123456789";
            string _value = identificacion.PadLeft(11, '0');
            string consts = "00123456789";
            Assert.Equal(_value, consts);
        }

        [Fact]
        public void ValidarPrefijo_8_numeros()
        {
            var identificacion = "12345678";
            string _value = identificacion.PadLeft(11, '0');
            string consts = "00012345678";
            Assert.Equal(_value, consts);
        }

        [Fact]
        public void ValidarPrefijo_7_numeros()
        {
            var identificacion = "1234567";
            string _value = identificacion.PadLeft(11, '0');
            string consts = "00001234567";
            Assert.Equal(_value, consts);
        }

        [Fact]
        public void ValidarPrefijo_6_numeros()
        {
            var identificacion = "123456";
            string _value = identificacion.PadLeft(11, '0');
            string consts = "00000123456";
            Assert.Equal(_value, consts);
        }

        [Fact]
        public void ValidarPrefijo_5_numeros()
        {
            var identificacion = "12345";
            string _value = identificacion.PadLeft(11, '0');
            string consts = "00000012345";
            Assert.Equal(_value, consts);
        }

        [Fact]
        public void ValidarPrefijo_4_numeros()
        {
            var identificacion = "1234";
            string _value = identificacion.PadLeft(11, '0');
            string consts = "00000001234";
            Assert.Equal(_value, consts);
        }

        [Fact]
        public void ValidarPrefijo_3_numeros()
        {
            var identificacion = "123";
            string _value = identificacion.PadLeft(11, '0');
            string consts = "00000000123";
            Assert.Equal(_value, consts);
        }

        [Fact]
        public void ValidarPrefijo_2_numeros()
        {
            var identificacion = "12";
            string _value = identificacion.PadLeft(11, '0');
            string consts = "00000000012";
            Assert.Equal(_value, consts);
        }

        [Fact]
        public void ValidarPrefijo_1_numeros()
        {
            var identificacion = "1";
            string _value = identificacion.PadLeft(11, '0');
            string consts = "00000000001";
            Assert.Equal(_value, consts);
        }

        [Fact]
        public void ValidarPrefijo_0_numeros()
        {
            var identificacion = "";
            string _value = identificacion.PadLeft(11, '0');
            string consts = "00000000000";
            Assert.Equal(_value, consts);
        }




    }
}

using Iot.Device.Ws28xx.Esp32;
using System.Threading;

namespace ESP32S3_RGBLED_Rainbow
{
    public class Program
    {
        public static void Main()
        {
            const int count = 1;    //LED�̐��@�I���{�[�hLED���ΏۂȂ̂łP
            const int ledPin = 48;  //LED��ڑ����Ă���GPIO�ԍ�

            int red, green, blue;

            Ws28xx led = new Ws2812c(ledPin, count);

            BitmapImage img = led.Image;

            while (true)
            {
                for(int i = 0; i < 255; i++)
                {
                    //�F���̈ʒu
                    int pos = i % 255;

                    //��>�i���j>�΂ƕω�����
                    if (pos < 85)
                    {
                        red = 255 - pos * 3;
                        green = pos * 3;
                        blue = 0;
                    }
                    //��>�i���F�j>�ƕω�����
                    else if(pos>=85 && pos < 170)
                    {
                        pos -= 85;
                        red = 0;
                        green = 255 - pos * 3;
                        blue = pos * 3;
                    }
                    //��>�i���j>�Ԃƕω�����
                    else
                    {
                        pos -= 170;
                        red = pos * 3;
                        green = 0;
                        blue = 255 - pos * 3;
                    }

                    //�F�̎w��̓o�C�g�^�Ȃ̂�(byte)�ŃL���X�g���܂��B
                    img.SetPixel(0, 0, (byte)red, (byte)green, (byte)blue);
                    led.Update();
                    //20ms���ɕω�
                    Thread.Sleep(20);
                }
            }
            
        }
    }
}

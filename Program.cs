using Iot.Device.Ws28xx.Esp32;
using System.Threading;

namespace ESP32S3_RGBLED_Rainbow
{
    public class Program
    {
        public static void Main()
        {
            const int count = 1;    //LEDの数　オンボードLEDが対象なので１
            const int ledPin = 48;  //LEDを接続しているGPIO番号

            int red, green, blue;

            Ws28xx led = new Ws2812c(ledPin, count);

            BitmapImage img = led.Image;

            while (true)
            {
                for(int i = 0; i < 255; i++)
                {
                    //色相の位置
                    int pos = i % 255;

                    //赤>（黄）>緑と変化する
                    if (pos < 85)
                    {
                        red = 255 - pos * 3;
                        green = pos * 3;
                        blue = 0;
                    }
                    //緑>（水色）>青と変化する
                    else if(pos>=85 && pos < 170)
                    {
                        pos -= 85;
                        red = 0;
                        green = 255 - pos * 3;
                        blue = pos * 3;
                    }
                    //青>（紫）>赤と変化する
                    else
                    {
                        pos -= 170;
                        red = pos * 3;
                        green = 0;
                        blue = 255 - pos * 3;
                    }

                    //色の指定はバイト型なので(byte)でキャストします。
                    img.SetPixel(0, 0, (byte)red, (byte)green, (byte)blue);
                    led.Update();
                    //20ms毎に変化
                    Thread.Sleep(20);
                }
            }
            
        }
    }
}

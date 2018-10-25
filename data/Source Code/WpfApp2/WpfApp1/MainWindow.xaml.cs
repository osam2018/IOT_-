using System;
using System.Collections.Generic;
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
using System.IO.Ports;
using System.Windows.Threading;
using MySql.Data.MySqlClient;
using System.Data;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private SerialPort arduSerialPort = new SerialPort();
        private string RData = "";

        private string dataPath = @"C:\curl\bin\data.json";
        private string batPath = @"C:\curl\bin\insert.bat";

        DispatcherTimer timer = new DispatcherTimer();    //객체생성

        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromMilliseconds(500);    //시간간격 설정
            timer.Tick += new EventHandler(timer_Tick);          //이벤트 추가
            timer.Start();
            Serial.Text = "아무 것도 눌리지 않음";
        }

        private void Arduino_Connect_Click(object sender, RoutedEventArgs e)
        {
            arduSerialPort.PortName = PortName.Text;    //아두이노가 연결된 시리얼 포트 번호 지정
            arduSerialPort.BaudRate = Int32.Parse(BaudRate.Text);       //시리얼 통신 속도 지정
            arduSerialPort.Encoding = Encoding.Default;
            arduSerialPort.Parity = Parity.None;
            arduSerialPort.DataBits = 8;
            arduSerialPort.StopBits = StopBits.One;
            arduSerialPort.DataReceived += new SerialDataReceivedEventHandler(Adruino_DataReceived);

            arduSerialPort.Open();                //포트 오픈
            
            if (arduSerialPort.IsOpen == true) //포트가 열려있다면
            {
                PortName.IsEnabled = false;
                BaudRate.IsEnabled = false;
                Arduino_Connect.IsEnabled = false;
            }
        }

        private void DB_Connect_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Int32.Parse(HMCount.Text); i++)
            {
                string textValue = "{\"name\":\"" + ES_NAME.Text + "\",\"state\":\"" + ES_STATE.Text + "\",\"date\":\"" + ES_DATE.Text + "\"}";
                System.IO.File.WriteAllText(dataPath, textValue);
                System.Diagnostics.Process.Start(batPath);
            }
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (arduSerialPort.IsOpen == true) //포트가 열려있다면
            {
                arduSerialPort.Close();        //포트를 닫는다
            }
        }

        private void Go_Click(object sender, RoutedEventArgs e)
        {
            if (arduSerialPort.IsOpen == true) //포트가 열려있다면
            {
                arduSerialPort.Write(Message.Text + ' ');
            }
        }
        private void Adruino_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            timer.Stop();
            int RSize = 0;
            RSize = arduSerialPort.BytesToRead;
            if (RSize != 0) // 수신된 데이터의 수가 0이 아닐때만 처리하자
            {
                RData = "";
                byte[] buff = new byte[RSize];

                arduSerialPort.Read(buff, 0, RSize);

                for (int i = 0; i < RSize; i++)
                {
                    RData += Convert.ToChar(buff[i]);
                }
            }
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if(RData.Length > 0)
            {
                bool flag = false;
                string state = "";
                switch (RData.First())
                {
                    case '1':
                        flag = true;
                        state = "Works";
                        Serial.Text = "근무";
                        RData = "";

                        if (arduSerialPort.IsOpen == true) //포트가 열려있다면
                        {
                            arduSerialPort.Write("Son, it's not easy, is it? But you can do it._ " + ' ');
                        }

                        break;
                    case '2':
                        flag = true;
                        state = "Human Relationships";
                        Serial.Text = "인간관계";
                        RData = "";
                        
                        if (arduSerialPort.IsOpen == true) //포트가 열려있다면
                        {
                            arduSerialPort.Write("Relations become tenacious when they are in an understanding relationship._ " + ' ');
                        }

                        break;
                    case '3':
                        flag = true;
                        state = "Nostalgic House";
                        Serial.Text = "집에 가고싶다";
                        RData = "";

                        if (arduSerialPort.IsOpen == true) //포트가 열려있다면
                        {
                            arduSerialPort.Write("I miss my son, too._ " + ' ');
                        }
                        
                        break;
                    case '4':
                        flag = true;
                        state = "Suicidal thoughts";
                        Serial.Text = "죽고싶다";
                        RData = "";

                        if (arduSerialPort.IsOpen == true) //포트가 열려있다면
                        {
                            arduSerialPort.Write("Don't think about that. There is us beside you who love you._ " + ' ');
                        }

                        break;
                }

                if (flag == true)
                {
                    string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    ES_DATE.Text = time;
                    string textValue = "{\"name\":\"" + ES_NAME.Text + "\",\"state\":\"" + state + "\",\"date\":\"" + time + "\"}";
                    System.IO.File.WriteAllText(dataPath, textValue);
                    System.Diagnostics.Process.Start(batPath);

                }

            }
            //여기에 실행시킬 구문을 입력하면 된다
        }
        

        /*
        private void Temp_Click(object sender, RoutedEventArgs e)
        {
            //Test 용
            if (DB_Connected)
            {
                //값이 입력됨
                string Time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                conn.Open();
                string insert_date_sql = "INSERT INTO BLUE_TABLE VALUES('" + military_serial_number + "','" + "인간관계" + "','" + Time + "');";
                MySqlCommand insert_date_cmd = new MySqlCommand(insert_date_sql, conn);
                insert_date_cmd.ExecuteNonQuery();
                conn.Close();
            }
        }*/
    }
}

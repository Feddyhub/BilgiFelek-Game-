using System;
using System.CodeDom;
using System.Windows.Forms;

namespace cark1
{
    public partial class Form1 : Form
    {
        /*combo box ici ile etkilesimli cevapler ,tek kelimelik ipucu stringleri-cevabi girecegimiz textbox
         -Guzel gorunen onay ve warning butonlari-hangi harften kac tane var o kodun icindekileri yan yana yazdirmak*/
        Random r = new Random();
        int[] wheel_fortune = { 0, 0, 0, 0, 0, 1000, 1000, 1000, 1000, 1000, 2500, 2500, 2500, 2500, 5000, 5000, 5000, 7500, 7500, 20000 };
        string[] bilmece = { "istanbul ", "Mitokondri", "astronot", "eczacilik", " jeoloji",/*0,4 -9 harfliler*/ "jenerator", "obsidiyen", "ulkuculuk", "alfabe", "on", "jeopolitik", "yadirgamak" };
        string[] ipucu = { "Megapol", "Biyoloji,", "Uzayli",  "meslek", "celal sengor ", "Benzinden elektrik uretir", "olusan en sert madde", "Bir ideoloji: osmaniye","28 harf","sayi","konum","bir duygu durum" };
        int[] freq = new int[10];
        string[] autogiven = { "b", "c", "d", "y", "z", "i" };
        string[] vowels = { "a", "e", "o", "u" };
        string random_bilmece;
        int point;
        string allgiven;
        int your_point = 0;
        string harf1;
        string harf2;
        int sayac = 0;
        int trigger1;
        int trigger2;
        bool button1Clicked = false;
        bool turn = false;
        int rastgele_index;
        int r_i1;
        int r_i2;
        int r_i3;
        string answer;
        bool kontrol = false;
        int multiple_point;
        int p = 0;
        string indeks_tutucu;


        public Form1()
        {
            InitializeComponent();


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            if (p <= 0)
            {

                if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Lütfen bir seçenek seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (comboBox1.SelectedIndex == 0)
                {
                     rastgele_index = r.Next(0, 4);
                    random_bilmece = bilmece[rastgele_index];
                    
                    //MessageBox.Show(random_bilmece);
                    label71.Text = "_ _ _ _ _ _ _ _";
                }
                if (comboBox1.SelectedIndex == 1)
                {
                     rastgele_index = r.Next(4, 7);
                    random_bilmece = bilmece[rastgele_index];
                    //MessageBox.Show(random_bilmece);
                    label71.Text = " _ _ _ _ _ _ _ _ _";
                }
                if (comboBox1.SelectedIndex == 2)
                {
                     rastgele_index = r.Next(7, bilmece.Length);
                    random_bilmece = bilmece[rastgele_index];
                    MessageBox.Show(random_bilmece);
                    label71.Text = " _ _ _ _ _ _ _ _ _ _ _";
                }



                // rastgele_index = r.Next(4, bilmece.Length);
                if ((textBox4.Text.Length == 3) && (textBox5.Text.Length == 1))
                {
                    button1Clicked = true;

                    int trigger1 = 0;
                    int trigger2 = 0;
                    //random_bilmece = bilmece[rastgele_index];
                    trigger1 = 0;
                    if (textBox4.Text.Length != 3)
                    {
                        MessageBox.Show("3 Harf gir");
                        trigger1 = 1;
                    }
                    else
                    {
                        for (int sayac = 0; sayac < textBox4.Text.Length; sayac++)
                        {

                            string harf1 = textBox4.Text.Substring(sayac, 1).ToLower();
                            if (vowels.Contains(harf1))
                            {

                                trigger1 = 1;
                                break;
                            }
                            else
                            {

                            }
                            if (trigger1 == 1) { break; }

                        }
                        if (trigger1 != 0) { MessageBox.Show("Lutfen Gecerli 3 sessiz harf giriniz : ", "SESLI HARF HATASI"); }
                        // AMAC 0 OLMALI

                    }
                    trigger2 = 0;
                    if (textBox5.Text.Length != 1)
                    {
                        MessageBox.Show("Lutfen Sadece 1 adet Sesli Harf gir");
                    }
                    else
                    {
                        for (int sayac = 0; sayac < textBox5.Text.Length; sayac++)
                        {

                            string harf2 = textBox5.Text.Substring(sayac, 1).ToLower();
                            if (vowels.Contains(harf2))
                            {
                                trigger2 = 1;
                                break;
                            }

                            if (trigger2 == 1) { break; }

                        }
                        if (trigger2 != 1) { MessageBox.Show("Lutfen Gecerli 1 SESLI harf giriniz (2)", "SESSIZ HARF HATASI"); }
                        // AMAC 1 OLMALI
                        // else { MessageBox.Show("basarili 2"); };


                    }
                    if (trigger1 == 0 && trigger2 == 1 && comboBox1.SelectedIndex != -1)
                    {
                        MessageBox.Show("Girisiniz Basarili");
                    }
                }
                else
                {
                    MessageBox.Show("BOS BIRAKILAMAZ !", "BOSLUK HATASI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    button1Clicked = false;

                }
            }
            // p>0 2.tur
            else
            {
                if ((textBox4.Text.Length == 1) && (textBox5.Text.Length == 0))
                {

                    trigger1 = 0;
                    if (textBox4.Text.Length != 1)
                    {
                        MessageBox.Show("Sadece 1 harf giriniz");
                        trigger1 = 1;
                    }
                    else
                    {
                        for (int sayac = 0; sayac < textBox4.Text.Length; sayac++)
                        {

                            string harf1 = textBox4.Text.Substring(sayac, 1).ToLower();
                            if (vowels.Contains(harf1))
                            {

                                trigger1 = 1;
                                break;
                            }
                            else
                            {

                            }
                            if (trigger1 == 1) { break; }

                        }
                        if (trigger1 != 0) { MessageBox.Show("Lutfen Gecerli 1 sessiz harf giriniz : ", "SESLI HARF VEYA HATALI TUSLAMA YAPTINIZ"); }
                        // AMAC 0 OLMALI

                    }
                    if (trigger1 == 0 && comboBox1.SelectedIndex != -1)
                    {
                        MessageBox.Show("Girisiniz Basarili");
                    }

                    else
                    {
                        MessageBox.Show("Lutfen sadece 1 sessiz harf giriniz sesli girmeyiniz !", "2.tur hatasi", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    }

                }
                else
                {
                    MessageBox.Show("Lutfen sadece 1 sessiz harf giriniz sesli harf girmeyiniz");
                }


            }


        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (button1Clicked == false)
            {
                MessageBox.Show("Öncelikle Harflerinizi kontrol ediniz!", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; //
            }
            else
            {
                label5.Text = wheel_fortune[r.Next(0, wheel_fortune.Length)].ToString();
                int multiple_point = int.Parse(label5.Text);
                sayac++;
                label8.Text = sayac.ToString();
                if (int.Parse(label5.Text) == 0) { sayac = 0; };

                your_point += multiple_point;
                label10.Text = your_point.ToString();


                if (turn == false)
                {
                    label15.Text = your_point.ToString();
                    while (Convert.ToInt64(label5.Text) == 0)
                    {
                        your_point = 0;
                        label15.Text = your_point.ToString();
                        MessageBox.Show("Sira Karsi Tarafta -");
                        turn = true;

                        break;
                    }

                }
                else
                {
                    label16.Text = your_point.ToString();
                    while (Convert.ToInt64(label5.Text) == 0)
                    {
                        your_point = 0;
                        label16.Text = your_point.ToString();
                        MessageBox.Show("Sira Karsi Tarafta -");
                        turn = false;
                        break;
                    }




                }

            }





        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            label3.Text = "UNVOWELS (1)";
            label4.Text = "XXXXXXXXX (0)";
            string harf1 = textBox4.Text;
            string harf2 = textBox5.Text;
            string allgiven = harf1 + harf2;
            string[] dizideneme = new string[10];

            foreach (string i in autogiven)
            {
                allgiven += i;
            }

            MessageBox.Show(allgiven.ToUpper() + "   " + "elimizdeki tum harfler birlesik sekilde");
            //MessageBox.Show("Aradigimiz kelime : " + random_bilmece);
           // MessageBox.Show("deneme" + "     " + allgiven + "      " + random_bilmece);
            int Max;
            if (allgiven.Length > bilmece.Length)
            {
                Max = allgiven.Length;
            }
            else { Max = bilmece.Length; }


            string[] kova = new string[Max];
            string[] indeks = new string[Max];
            //string[] kova2 = new string[Max];



            for (int i = 0; i < allgiven.Length; i++)
            {
                for (int j = 0; j < random_bilmece.Length; j++)
                {
                    if (random_bilmece[j] == allgiven[i])
                    {

                        freq[i]++;
                        MessageBox.Show($"Bu harf bulunmakta : ({allgiven[i]}) --{freq[i]}. kez bulunmakta {j + 1}. sırada");
                        kova[i] = allgiven[i].ToString();
                        indeks[i] = (j + 1).ToString();
                        richTextBox3.AppendText("  "+kova[i]+"  ");
                        richTextBox1.AppendText("  "+indeks[i] + "  ");

                    }


                }
                

            }

                   
            
         


                textBox4.Text = "";
                textBox5.Text = "";
                p = 1;

            



        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                random_bilmece = bilmece[r.Next(0, random_bilmece.Length)];

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string uyari = "Eger ipucu alirsaniz kazandiginiz puan yariya dusecek ve yanlis tahmin ederseniz puaniniz -2x Olacak Onayliyor Musunuz ?";
            string box_title = "ipucu Tercihi ";

            DialogResult result = MessageBox.Show(uyari, box_title, MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                MessageBox.Show(random_bilmece);
                MessageBox.Show(rastgele_index.ToString());
                kontrol = true;
                MessageBox.Show(ipucu[rastgele_index]);
                your_point = (your_point/2);
                label5.Text= your_point.ToString();
                
            }
            else if (result == DialogResult.Cancel)
            {
                MessageBox.Show("Cancel butonuna basildi.");
            }

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        { }
        private void Form1_Load(object sender, EventArgs e)
        { }
        private void label71_Click(object sender, EventArgs e)
        { }
        private void button5_Click(object sender, EventArgs e)
        {
            
            int r1 = r.Next(0,random_bilmece.Length);
            int r2 = r.Next(0, random_bilmece.Length);
            if (r1 < r2) 
            {
                string subString = random_bilmece.Substring(r1, r2);
                richTextBox2.Text = subString;
            }
            else
            {
                string subString = random_bilmece.Substring(r2, r1);
                richTextBox2.Text = subString;
            }
   

        }


        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string currentText = richTextBox2.Text;  // Kullanıcının şu anki girdisini al

            if (kontrol == true)
            {
                if (answer != random_bilmece.ToString())  // Önceki girdiyle şimdiki girdiyi karşılaştır
                {
                    your_point = -2 * multiple_point;

                    MessageBox.Show("ipuculu bilemedin");
                    int sifir = 0;
                    label15.Text = sifir.ToString();
                    label16.Text = sifir.ToString();
                    label5.Text = sifir.ToString();
                    label10.Text = sifir.ToString();
                    turn = !turn;
                }
                else { MessageBox.Show("ipuculu bildin"); }
            }
            else
            {
                if (answer != currentText)  // Önceki girdiyle şimdiki girdiyi karşılaştır
                {
                    int sifir = 0;
                    label15.Text = sifir.ToString();
                    label16.Text = sifir.ToString();
                    label5.Text = sifir.ToString();
                    label10.Text = sifir.ToString();
                    turn = !turn;
                    MessageBox.Show("ipucusuz bilemedin");
                }
                else
                {
                    MessageBox.Show("ipucusuz bildin");
                }
            }
            
        }


        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}


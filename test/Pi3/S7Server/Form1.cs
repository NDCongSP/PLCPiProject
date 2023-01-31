﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using PLCPiProject;

namespace S7Server
{
    public partial class Form1 : Form
    {
        //Tao doi tuong myPLC
        PLCPi myPLC = new PLCPi();
        string trangthai;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            trangthai = myPLC.S7Ethernet.Server.Khoitao();

            if (trangthai == "GOOD")
            {
                panel1.BackColor = Color.Green;
            }
            else
            {
                panel1.BackColor = Color.Red;
            }
            timer1.Enabled = true;
            System.Threading.Thread.Sleep(1000);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
               
                label2.Text = Convert.ToString(myPLC.S7Ethernet.Server.DataBlock[1]);
                label4.Text = Convert.ToString(myPLC.S7Ethernet.Server.NgoRa.MangNgoRa[1]);
                label5.Text = Convert.ToString(myPLC.S7Ethernet.Server.NgoVao.MangNgoVao[1]);
                myPLC.S7Ethernet.Server.DataBlock[0] = Convert.ToByte(textBox2.Text);

                myPLC.NgoVao.DocNgoVao("I1");
                if (label4.Text != null)
                {
                    myPLC.NgoRa.XuatNgoRa("Q1", Convert.ToByte(label4.Text));
                }
           
        }

        
    }
}

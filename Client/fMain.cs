﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class fMain : Form
    {
        Client theClient;
        private fMain()
        {

        }
        public fMain(Client theClient)
        {
            InitializeComponent();
            this.theClient = theClient;
        }
    }
}

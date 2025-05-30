﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoFact.Models;
using System.Data.SQLite;

namespace AutoFact.Views;

public partial class Home : Form
{
    private BackgroundPanel backgroundPanel;
    private SQLiteConnection connection;
    public Home()
    {
        InitializeComponent();
        InitializeDatabase();
    }

    private void InitializeDatabase()
    {
        DataBaseManager data = DataBaseManager.getInstance();
        connection = data.getConnection();
    }
}
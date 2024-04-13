﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelSelect.Dao.impl;
using HotelSelect.Dao.inreface;
using HotelSelect.Dao.service;
using HotelSelect.Entity;

namespace HotelSelect
{
    public partial class RegForm : Form
    {

        private IUserDao userService = new UserService();
        public RegForm()
        {
            InitializeComponent();
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User newUser = new User();
            newUser.FirstName = firstName.Text;
            newUser.LastName = lastName.Text;
            newUser.Age = birthDay.Value;
            newUser.Email = email.Text;
            newUser.Login = login.Text;
            newUser.Password = password.Text;
            newUser.CityId = 1;
            newUser.CountryId = 1;
            newUser.PhoneNumber = phoneNumber.Text;
            
            userService.SaveUser(newUser);
        }
    }
}

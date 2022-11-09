﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRegister.ViewModels.ViewModels
{
    public class RegisterApplicationViewModel
    {
        public int StudentId { get; set; }
        public int IdStatus { get; set; }
        public DateTime DateRegister { get; set; }
        public DateTime DateReceived { get; set; }
        public int ApplicationId { get; set; }
        public int Id { get; set; }
        public string Content { get; set; }
        public string Dear { get; set; }
        public string Student { get; set; }
        public string NameApp { get; set; }
        public string Status { get; set; }
        public string UserName { get; set; }
        public Guid UserId { get; set; }
    }
}

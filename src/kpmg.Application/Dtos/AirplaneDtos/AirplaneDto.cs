﻿#region

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using kpmg.Application.Bases;

#endregion

namespace kpmg.Application.Dtos.AirplaneDtos
{
    public class AirplaneDto : EntityDto
    {
        public int Id { get; set; }

        [DisplayName("Codigo")]
        [Required(ErrorMessage = "Please enter a Codigo")]
        public string Codigo { get; set; }

        public string Modelo { get; set; }
        public int QuantidadePassageiro { get; set; }
        public DateTime DataRegistro { get; set; }
    }
}
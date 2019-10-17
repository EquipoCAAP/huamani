﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace sb_admin.web.Models
{
    public class personaMetadata
    {
        [StringLength(10)]
        [Display(Name = "identificación")]
        public string dni;

        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string nombre;

        [StringLength(50)]
        [Display(Name = "Apellido")]
        public string apellido;
        [StringLength(8)]
        [Display(Name = "Celular")]
        public string celular;

        [Display(Name = "Tipo de Persona")]
        public string tipo_persona;

    }

    public class telefonoMetadata
    {
        [Display(Name = "Tipo de telefono")]
        public string tipo_telefono;
        [Display(Name = "Tipo de Persona")]
        public string telefono1;
    }
}
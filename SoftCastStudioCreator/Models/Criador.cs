﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCastStudioCreator.Models
{
    public class Criador
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public List<Conteudo> Conteudos { get; set; } = new List<Conteudo>();
    }
}

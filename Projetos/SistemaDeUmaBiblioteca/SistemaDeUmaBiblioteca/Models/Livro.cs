using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeUmaBiblioteca.Models
{
    public class Livro
    {
        private string? _altorName;
        public string? NameAltor
        {
            get => this._altorName;
            set
            {
                if (string.IsNullOrWhiteSpace (value)) throw new Exception ("Favor informe o nome do altor do livro...");
                this._altorName = value;
            }
        }
        private string? _titulo;
        public string? Titulo
        {
            get => this._titulo;
            set
            {
                if (string.IsNullOrWhiteSpace (value)) throw new Exception ("Favor informe o titulo do livro...");
                this._titulo = value;
            }
        }
        private string? _genero;
        public string? Genero
        {
            get => this._genero;
            set
            {
                if (string.IsNullOrWhiteSpace (value)) throw new Exception ("Favor informe o gênero do livro...");
                this._genero = value;
            }
        }
        private string? _qntPaginas;
        public string? QantPaginas
        {
            get => this._qntPaginas;
            set
            {
                if (string.IsNullOrWhiteSpace (value)) throw new Exception ("Favor informe quantas paginas tem o livro");
                if (!int.TryParse (value, out int paginas)) throw new Exception ("Número de pagians invalido...");
                if (paginas <= 29) throw new Exception ("Não é possível um livro ter menos de 30 paginas...");
                this._qntPaginas = value;
            }
        }

        public string? GetAltor () => this._altorName;
        public string? GetTitulo () => this._titulo;
        public string? GetGenero () => this._genero;
        public string? GetQntPaginas () => this._qntPaginas;
    }
}
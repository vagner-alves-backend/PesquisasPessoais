using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SistemaDeCadastrosCom_JSON.Models
{
    public class ListaDados<T> : IEnumerable<T>
    {
        private readonly List<T> _dados = [];
        public int CountElement => _dados.Count;
        public bool ContemElementos => _dados.Count > 0;
        public void AddRegistro(T element) => _dados.Add(element);

        public IEnumerator<T> GetEnumerator() => _dados.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _dados.GetEnumerator();

        public T this[int index]
        {
            get => _dados[index];
            set => _dados[index] = value;
        }
    }
}

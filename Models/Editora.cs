using System.Collections.Generic;
using Newtonsoft.Json;

namespace WebApiLivrariaVirtual.Models
{
    public class Editora
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}


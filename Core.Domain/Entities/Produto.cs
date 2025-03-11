
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Entities
{
    public class Produto
    {
        // Identificador único usando Guid
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        [BsonId]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string? Nome { get; set; } 

        [Range(0.01, double.MaxValue, ErrorMessage = "O campo Preço deve ser maior que zero.")]
        public decimal Preco { get; set; }

        public string? Descricao { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "O campo Estoque não pode ser negativo.")]
        public int Estoque { get; set; }

        /// <summary>
        /// Atualiza o estoque do produto.
        /// </summary>
        /// <param name="quantidade">Nova quantidade em estoque.</param>
        /// <exception cref="InvalidOperationException">Lança exceção se a quantidade for negativa.</exception>
        public void AtualizarEstoque(int quantidade)
        {
            if (quantidade < 0)
                throw new InvalidOperationException("A quantidade não pode ser negativa.");

            Estoque = quantidade;
        }
    }
}































//using MongoDB.Bson;
//using MongoDB.Bson.Serialization.Attributes;
//using System.ComponentModel.DataAnnotations;

//namespace Core.Domain.Entities
//{

//    public class Produto
//    {
//        //versao nova, adicionado um validador para os modelos com Data Annotations
//        [BsonRepresentation(BsonType.ObjectId)]
//        [BsonId]
//        public ObjectId Id { get; set; }


//        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
//        public string Nome { get; set; } = null!;

//        [Range(0.01, double.MaxValue, ErrorMessage = "O campo Preço deve ser maior que zero.")]
//        public decimal Preco { get; set; } 

//        public string? Descricao { get; set; }

//        [Range(0, int.MaxValue, ErrorMessage = "O campo Estoque não pode ser negativo.")]
//        public int Estoque { get; set; }
//    }
//}

//using MongoDB.Bson;
//using MongoDB.Bson.Serialization.Attributes;

//namespace Core.Domain.Entities
//{
//    public class Produto
//    {
//        [BsonId] // Define que este é o ID do MongoDB
//        public ObjectId Id { get; set; } // Alterado de string para ObjectId

//        public string Nome { get; set; }
//        public decimal Preco { get; set; }
//        public int Estoque { get; set; }
//    }
//}






//versao antiga

//    public class Produto
//    {
//        [BsonId]
//        [BsonRepresentation(BsonType.ObjectId)]
//        public string? Id { get; set; } = null!;

//        public string Nome { get; set; } = null!;
//        public string Descricao { get; set; } = null!;
//        public decimal Preco { get; set; }
//        public int Estoque { get; set; }
//    }
//}

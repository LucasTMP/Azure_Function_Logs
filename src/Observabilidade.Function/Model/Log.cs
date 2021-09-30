using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Nest;
using Newtonsoft.Json;
using Observabilidade.Function.Model.Validations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Observabilidade.Function.Model
{
    public class Log
    {
        [BsonIgnore()]
        private IList<string> _falhasValidacao;

        [Ignore, JsonIgnore]
        [BsonIgnore()]
        public IList<string> FalhasValidacao
        {
            get
            {
                return new ReadOnlyCollection<string>(_falhasValidacao);
            }
            private set
            {
                _falhasValidacao = value;
            }
        }
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }
        public string NomeAplicacao { get; private set; }
        public string Mensagem { get; private set; }
        public string Detalhe { get; private set; }
        public DateTime DataDeCriacao { get; private set; }

        public Log()
        {
            _falhasValidacao = new List<string>();
        }

        [JsonConstructor]
        public Log(string id, string nomeAplicacao, string mensagem, string detalhe)
        {
            Id = id;
            NomeAplicacao = nomeAplicacao;
            Mensagem = mensagem;
            Detalhe = detalhe;
            DataDeCriacao = DateTime.Now;
            _falhasValidacao = new List<string>();
        }

        public bool IsInvalid()
        {
            var validator = new LogValidator().Validate(this).Errors;
            validator.ForEach(x => _falhasValidacao.Add(x.ErrorMessage));
            return validator.Any();
        }
    }
}
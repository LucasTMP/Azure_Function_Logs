using FluentValidation.TestHelper;
using Observabilidade.Function.Model.Validations;
using System;
using Xunit;

namespace Observabilidade.Function.Tests
{
    public class LogValidatorTests
    {
        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData(" ", " ")]        
        public void FieldEmpty_ReturnErrorMessage(string nomeAplicacao, string mensagem)
        {
            var result = new LogValidator();

            result.ShouldHaveValidationErrorFor(log => log.NomeAplicacao, nomeAplicacao);
            result.ShouldHaveValidationErrorFor(log => log.Mensagem, mensagem);
        }

        [Fact]
        public void MessageIsOver1000Chars_ReturnErrorMessage()
        {
            var result = new LogValidator();

            result.ShouldHaveValidationErrorFor(log => log.Detalhe, new string('x', 1001));
        }

        [Fact]
        public void MessageIsUnder1000Chars_ReturnErrorMessage()
        {
            var result = new LogValidator();

            result.ShouldNotHaveValidationErrorFor(log => log.Detalhe, new string('x', 999));
        }

        [Fact]
        public void MessageIs1000Chars_ReturnErrorMessage()
        {
            var result = new LogValidator();

            result.ShouldNotHaveValidationErrorFor(log => log.Detalhe, new string('x', 1000));
        }

        [Fact]
        public void NomeAplicacaoIsUnder5Chars_ReturnErrorMessage()
        {
            var result = new LogValidator();

            result.ShouldHaveValidationErrorFor(log => log.NomeAplicacao, new string('x', 4));
        }

        [Fact]
        public void NomeAplicacaoIs5Chars_ReturnErrorMessage()
        {
            var result = new LogValidator();

            result.ShouldNotHaveValidationErrorFor(log => log.NomeAplicacao, new string('x', 5));
        }

        [Fact]
        public void NomeAplicacaoIs50Chars_ReturnErrorMessage()
        {
            var result = new LogValidator();

            result.ShouldNotHaveValidationErrorFor(log => log.NomeAplicacao, new string('x', 50));
        }

        [Fact]
        public void NomeAplicacaoIsOver50Chars_ReturnErrorMessage()
        {
            var result = new LogValidator();

            result.ShouldHaveValidationErrorFor(log => log.NomeAplicacao, new string('x', 51));
        }

        [Fact]
        public void MensageIsUnder10Chars_ReturnErrorMessage()
        {
            var result = new LogValidator();

            result.ShouldHaveValidationErrorFor(log => log.Mensagem, new string('x', 9));
        }

        [Fact]
        public void MensageIs10Chars_ReturnErrorMessage()
        {
            var result = new LogValidator();

            result.ShouldNotHaveValidationErrorFor(log => log.Mensagem, new string('x', 10));
        }

        [Fact]
        public void MensageIs250Chars_ReturnErrorMessage()
        {
            var result = new LogValidator();

            result.ShouldNotHaveValidationErrorFor(log => log.Mensagem, new string('x', 250));
        }

        [Fact]
        public void MensageIsOver250Chars_ReturnErrorMessage()
        {
            var result = new LogValidator();

            result.ShouldHaveValidationErrorFor(log => log.Mensagem, new string('x', 251));
        }
    }
}

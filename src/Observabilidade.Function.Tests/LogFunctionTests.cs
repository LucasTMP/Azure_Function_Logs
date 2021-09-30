using Castle.Core.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Moq;
using Moq.AutoMock;
using Newtonsoft.Json;
using Observabilidade.Function.Model;
using Observabilidade.Function.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Observabilidade.Function.Tests
{
    public class LogFunctionTests
    {
        private AutoMocker _mocker;

        public LogFunctionTests()
        {
            _mocker = new AutoMocker();
        }

        [Fact]
        public async Task Run_ReturnError_LogIsNull()
        {
            var result = _mocker.CreateInstance<LogFunction>();

            var executionContext = FakeFunctionContext.CreateFunctionContext();

            var req = new FakeHttpRequestData(executionContext);

            var runResult = await result.Run( req, executionContext);

            Assert.Equal(HttpStatusCode.BadRequest, runResult.StatusCode);
        }

        [Fact]
        public async Task Run_ReturnError_LogIsInvalid()
        {
            var result = _mocker.CreateInstance<LogFunction>();

            var executionContext = FakeFunctionContext.CreateFunctionContext();

            var req = new FakeHttpRequestData(executionContext);

            var log = new Log("1", "Teste.Api", "", "Detalhe");

            var objetoSerializado = JsonConvert.SerializeObject(log);

            req.Body.Write(Encoding.ASCII.GetBytes(objetoSerializado));

            req.Body.Position = 0;

            var runResult = await result.Run(req, executionContext);

            Assert.Equal(HttpStatusCode.BadRequest, runResult.StatusCode);
        }

        [Fact]
        public async Task Run_ReturnError_AddLogFailed()
        {
            var result = _mocker.CreateInstance<LogFunction>();

            var serviceMock = _mocker.GetMock<ILogService>();

            serviceMock.Setup(x => x.AddLog(It.IsAny<Log>())).ThrowsAsync(new Exception());

            var executionContext = FakeFunctionContext.CreateFunctionContext();

            var req = new FakeHttpRequestData(executionContext);

            var log = new Log("1", "Teste.Api", "Aécio é a referência", "Detalhe");

            var objetoSerializado = JsonConvert.SerializeObject(log);

            req.Body.Write(Encoding.ASCII.GetBytes(objetoSerializado));

            req.Body.Position = 0;

            var runResult = await result.Run(req, executionContext);

            Assert.Equal(HttpStatusCode.InternalServerError, runResult.StatusCode);
        }

        [Fact]
        public async Task Run_ReturnOk_ValidLog()
        {
            var result = _mocker.CreateInstance<LogFunction>();

            var executionContext = FakeFunctionContext.CreateFunctionContext();

            var req = new FakeHttpRequestData(executionContext);

            var log = new Log("1", "Teste.Api", "Aécio é a referência", "Detalhe");

            var objetoSerializado = JsonConvert.SerializeObject(log);

            req.Body.Write(Encoding.ASCII.GetBytes(objetoSerializado));

            req.Body.Position = 0;

            var runResult = await result.Run(req, executionContext);

            Assert.Equal(HttpStatusCode.OK, runResult.StatusCode);
        }

    }



    public class FakeFunctionContext : FunctionContext
    {
        public static FunctionContext CreateFunctionContext(ILogger logger = null)
        {
            logger = logger ?? null;

            var LoggerFactory = new Mock<ILoggerFactory>();
            //LoggerFactory.Setup(p (It.IsAny<string>())).Returns(logger);

            var InstanceServices = new Mock<IServiceProvider>();
            InstanceServices.Setup(p => p.GetService(It.IsAny<Type>())).Returns(LoggerFactory.Object);

            var context = new Mock<FunctionContext>();
            context.Setup(p => p.InstanceServices).Returns(InstanceServices.Object);
            return context.Object;
        }

        public override string InvocationId => throw new NotImplementedException();

        public override string FunctionId => throw new NotImplementedException();

        public override TraceContext TraceContext => throw new NotImplementedException();

        public override BindingContext BindingContext => throw new NotImplementedException();

        public override IServiceProvider InstanceServices { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override FunctionDefinition FunctionDefinition => throw new NotImplementedException();

        public override IDictionary<object, object> Items { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override IInvocationFeatures Features => throw new NotImplementedException();
    }

    public class FakeHttpRequestData : HttpRequestData
    {
        public FakeHttpRequestData(FunctionContext functionContext) : base(functionContext)
        {
        }

        public override Stream Body { get; } = new MemoryStream();

        public override HttpHeadersCollection Headers { get; } = new HttpHeadersCollection();

        public override IReadOnlyCollection<IHttpCookie> Cookies { get; }

        public override Uri Url { get; }

        public override IEnumerable<ClaimsIdentity> Identities { get; }

        public override string Method { get; }

        public override HttpResponseData CreateResponse()
        {
            return new FakeHttpResponseData(FunctionContext);
        }
    }

    public class FakeHttpResponseData : HttpResponseData
    {
        public FakeHttpResponseData(FunctionContext functionContext) : base(functionContext)
        {
        }

        public override HttpStatusCode StatusCode { get; set; }
        public override HttpHeadersCollection Headers { get; set; } = new HttpHeadersCollection();
        public override Stream Body { get; set; } = new MemoryStream();
        public override HttpCookies Cookies { get; }
    }


}

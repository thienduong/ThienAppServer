using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Framework
{
    /// <summary>
    /// Base response result
    /// </summary>

    public class HttpApiActionResult : IHttpActionResult
    {
        private readonly HttpStatusCode _statusCode;
        private readonly ApiJsonResult _result;
        /// <summary>
        /// Get api json result
        /// </summary>
        public ApiJsonResult Content { get { return _result; } }

        public HttpApiActionResult(HttpStatusCode statusCode, ApiJsonResult result)
        {
            _statusCode = statusCode;
            _result = result;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var camelCaseFormatter = new JsonSerializerSettings();
            camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();

            var jsonResult = JsonConvert.SerializeObject(_result, camelCaseFormatter);
            JToken json = JObject.Parse(jsonResult);

            HttpResponseMessage response = new HttpResponseMessage(_statusCode)
            {
                Content = new JsonContent(json),

            };
            return Task.FromResult(response);
        }
    }
    public class JsonContent : HttpContent
    {
        private readonly JToken _value;

        public JsonContent(JToken value)
        {
            _value = value;
            Headers.ContentType = new MediaTypeHeaderValue("application/json");
        }

        protected override Task SerializeToStreamAsync(Stream stream,
            TransportContext context)
        {
            var jw = new JsonTextWriter(new StreamWriter(stream))
            {
                Formatting = Formatting.Indented
            };
            _value.WriteTo(jw);
            jw.Flush();
            return Task.FromResult<object>(null);
        }

        protected override bool TryComputeLength(out long length)
        {
            length = -1;
            return false;
        }
    }
}

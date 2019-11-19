using System;
using System.Collections.Generic;

namespace Stellers.Hawkeye.Logging
{
	public class Logger : ILogger
	{
		readonly Serilog.ILogger _logger;

		public Logger(Serilog.ILogger logger)
		{
			_logger = logger;
		}

		public void Debug(Common.Enumerations.Log.Category category, string messageTemplate, IDictionary<string, object> additionalProperties = null, params object[] propertyValues)
		{
			AddToContext(_logger, category, additionalProperties).Debug(messageTemplate, propertyValues);
		}

		public void Debug(Common.Enumerations.Log.Category category, Exception exception, IDictionary<string, object> additionalProperties = null)
		{
			AddToContext(_logger, category, additionalProperties).Debug(exception, exception.Message);
		}

		public void Debug(Common.Enumerations.Log.Category category, string messageTemplate, Exception exception, IDictionary<string, object> additionalProperties = null, params object[] propertyValues)
		{
			AddToContext(_logger, category, additionalProperties).Debug(exception, messageTemplate, propertyValues);
		}

		public string Error(Common.Enumerations.Log.Category category, string messageTemplate, IDictionary<string, object> additionalProperties = null, params object[] propertyValues)
		{
			var corelationId = GetCorelationId;
			AddToContext(_logger, category, additionalProperties)
				   .ForContext(nameof(corelationId), corelationId)
				   .Error(messageTemplate, propertyValues);
			return corelationId;
		}

		public string Error(Common.Enumerations.Log.Category category, Exception exception, IDictionary<string, object> additionalProperties = null)
		{
			var corelationId = GetCorelationId;
			AddToContext(_logger, category, additionalProperties)
				   .ForContext(nameof(corelationId), corelationId)
				   .Error(exception, exception.Message);
			return corelationId;
		}

		public string Error(Common.Enumerations.Log.Category category, string messageTemplate, Exception exception, IDictionary<string, object> additionalProperties = null, params object[] propertyValues)
		{
			var corelationId = GetCorelationId;
			AddToContext(_logger, category, additionalProperties)
				   .ForContext(nameof(corelationId), corelationId)
				   .Error(exception, messageTemplate, propertyValues);
			return corelationId;
		}

		public string Fatal(Common.Enumerations.Log.Category category, string messageTemplate, IDictionary<string, object> additionalProperties = null, params object[] propertyValues)
		{
			var corelationId = GetCorelationId;
			AddToContext(_logger, category, additionalProperties)
				   .ForContext(nameof(corelationId), corelationId)
				   .Fatal(messageTemplate, propertyValues);
			return corelationId;
		}

		public string Fatal(Common.Enumerations.Log.Category category, Exception exception, IDictionary<string, object> additionalProperties = null)
		{
			var corelationId = GetCorelationId;
			AddToContext(_logger, category, additionalProperties)
				   .ForContext(nameof(corelationId), corelationId)
				   .Fatal(exception, exception.Message);
			return corelationId;
		}

		public string Fatal(Common.Enumerations.Log.Category category, string messageTemplate, Exception exception, IDictionary<string, object> additionalProperties = null, params object[] propertyValues)
		{
			var corelationId = GetCorelationId;
			AddToContext(_logger, category, additionalProperties)
				   .ForContext(nameof(corelationId), corelationId)
				   .Fatal(exception, messageTemplate, propertyValues);
			return corelationId;
		}

		public void Information(Common.Enumerations.Log.Category category, string messageTemplate, IDictionary<string, object> additionalProperties = null, params object[] propertyValues)
		{
			AddToContext(_logger, category, additionalProperties).Information(messageTemplate, propertyValues);
		}

		public void Information(Common.Enumerations.Log.Category category, Exception exception, IDictionary<string, object> additionalProperties = null)
		{
			AddToContext(_logger, category, additionalProperties).Information(exception, exception.Message);
		}

		public void Information(Common.Enumerations.Log.Category category, string messageTemplate, Exception exception, IDictionary<string, object> additionalProperties = null, params object[] propertyValues)
		{
			AddToContext(_logger, category, additionalProperties).Information(exception, messageTemplate, propertyValues);
		}

		public void Verbose(Common.Enumerations.Log.Category category, string messageTemplate, IDictionary<string, object> additionalProperties = null, params object[] propertyValues)
		{
			AddToContext(_logger, category, additionalProperties).Information(messageTemplate, propertyValues);
		}

		public void Verbose(Common.Enumerations.Log.Category category, Exception exception, IDictionary<string, object> additionalProperties = null)
		{
			AddToContext(_logger, category, additionalProperties).Information(exception, exception.Message);
		}

		public void Verbose(Common.Enumerations.Log.Category category, string messageTemplate, Exception exception, IDictionary<string, object> additionalProperties = null, params object[] propertyValues)
		{
			AddToContext(_logger, category, additionalProperties).Information(exception, messageTemplate, propertyValues);
		}

		public void Warning(Common.Enumerations.Log.Category category, string messageTemplate, IDictionary<string, object> additionalProperties = null, params object[] propertyValues)
		{
			AddToContext(_logger, category, additionalProperties).Warning(messageTemplate, propertyValues);
		}

		public void Warning(Common.Enumerations.Log.Category category, Exception exception, IDictionary<string, object> additionalProperties = null)
		{
			AddToContext(_logger, category, additionalProperties).Information(exception, exception.Message);
		}

		public void Warning(Common.Enumerations.Log.Category category, string messageTemplate, Exception exception, IDictionary<string, object> additionalProperties = null, params object[] propertyValues)
		{
			AddToContext(_logger, category, additionalProperties).Information(exception, messageTemplate, propertyValues);
		}

		private string GetCorelationId => Guid.NewGuid().ToString();

		private Serilog.ILogger AddToContext(Serilog.ILogger _logger, Common.Enumerations.Log.Category category, IDictionary<string, object> additionalProperties = null)
		{
			return _logger.ForContext(nameof(category), category)
						  .ForContext(nameof(additionalProperties), additionalProperties, true);
		}
	}
}
